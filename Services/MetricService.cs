using tik4net;
using tik4net.Objects;
using tik4net.Objects.Ip.Firewall;

namespace HypeProxy.PrometheusExporter.MikrotikActiveConnections.Services;

public class MetricService
{
	public List<FirewallConnection> GetConnections()
	{
		var host = Environment.GetEnvironmentVariable("MIKROTIK_ROUTER_ADDRESS") ?? "127.0.0.1";
		var port = int.TryParse(Environment.GetEnvironmentVariable("MIKROTIK_ROUTER_PORT"), out var parsedPort) ? parsedPort : 8728;
		var username = Environment.GetEnvironmentVariable("MIKROTIK_ROUTER_USERNAME") ?? throw new ArgumentException("Environment variable 'MIKROTIK_ROUTER_USERNAME' is missing.");
		var password = Environment.GetEnvironmentVariable("MIKROTIK_ROUTER_PASSWORD") ?? throw new ArgumentException("Environment variable 'MIKROTIK_ROUTER_PASSWORD' is missing.");
		
		using var connection = ConnectionFactory.OpenConnection(TikConnectionType.Api, host, port, username, password);
		return connection.LoadAll<FirewallConnection>().ToList();
	}
}