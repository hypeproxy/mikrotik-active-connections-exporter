using tik4net;
using tik4net.Objects;
using tik4net.Objects.Ip.Firewall;

namespace HypeProxy.PrometheusExporter.MikrotikActiveConnections.Services;

public class MetricService
{
	public List<FirewallConnection> GetConnections()
	{
		const string host = "10.2.0.1";
		const int port = 18728;
		const string username = "mikrotik-exporter";
		const string password = "9rwETnKPtBJquqPD#Mg%GeFumHb$9H";
		
		using var connection = ConnectionFactory.OpenConnection(TikConnectionType.Api, host, port, username, password);
		return connection.LoadAll<FirewallConnection>().ToList();
	}
}