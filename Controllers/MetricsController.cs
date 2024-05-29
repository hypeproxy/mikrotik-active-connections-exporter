using HypeProxy.PrometheusExporter.MikrotikActiveConnections.Services;
using Microsoft.AspNetCore.Mvc;
using tik4net.Objects.Ip.Firewall;

namespace HypeProxy.PrometheusExporter.MikrotikActiveConnections.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetricsController(MetricService metricService) : ControllerBase
{
	[HttpGet("connections")]
	public IEnumerable<FirewallConnection> Get() => metricService.GetConnections();
}