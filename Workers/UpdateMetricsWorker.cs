using System.Globalization;
using System.Net;
using HypeProxy.PrometheusExporter.MikrotikActiveConnections.Services;
using MaxMind.GeoIP2;
using Prometheus;

namespace HypeProxy.PrometheusExporter.MikrotikActiveConnections.Workers;

public class UpdateMetricsWorker(ILogger<UpdateMetricsWorker> logger, MetricService metricService) : BackgroundService
{
    private static readonly Gauge MikrotikTotalConnectionsGauge = Metrics
        .CreateGauge("mikrotik_total_connections", "Total number of active connections on MikroTik router");
    
    private static readonly Gauge MikrotikConnectionGauge = Metrics
        .CreateGauge("mikrotik_connection", "Active connections on MikroTik router", new GaugeConfiguration
        {
            LabelNames = [
                "id", "src_address", "dst_address", "protocol", "tcp_state", "timeout", "connection_type", "connection_mark", "reply_dst_address", "reply_src_address", 
                "city", "country", "latitude", "longitude"
            ]
        });

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("UpdateMetricsWorker started at: {time}", DateTimeOffset.Now);
        
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Fetching connections at: {time}", DateTimeOffset.Now);
            
            var connections = metricService.GetConnections();
            
            MikrotikConnectionGauge.Unpublish();
            MikrotikTotalConnectionsGauge.Set(connections.Count);
            
            using var reader = new DatabaseReader("GeoIP2-City.mmdb");
            
            foreach (var connection in connections)
            {
                var city = "-";
                var country = "-";
                double latitude = 0;
                double longitude = 0;

                try
                {
                    var ip = IPEndPoint.Parse(connection.DstAddress).Address;
                    var response = reader.City(ip);
                    city = response.City.Name ?? "-";
                    country = response.Country.Name ?? "-";
                    latitude = response.Location.Latitude ?? 0;
                    longitude = response.Location.Longitude ?? 0;
                }
                catch (Exception e)
                {
                    logger.LogWarning("Could not determine location for IP {ip}: {exception}", connection.SrcAddress, e.Message);
                }
                
                MikrotikConnectionGauge.WithLabels(
                    connection.Id,
                    connection.SrcAddress,
                    connection.DstAddress,
                    connection.Protocol,
                    connection.TcpState,
                    connection.Timeout,
                    connection.ConnectionType,
                    connection.ConnectionMark,
                    connection.ReplyDstAddress,
                    connection.ReplySrcAddress,
                    city,
                    country,
                    latitude.ToString(CultureInfo.InvariantCulture),
                    longitude.ToString(CultureInfo.InvariantCulture)
                ).Set(1);
            }
            
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}