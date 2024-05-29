using Microsoft.AspNetCore.Mvc;

namespace HypeProxy.PrometheusExporter.MikrotikActiveConnections.Controllers;

public class HomeController : Controller
{
	[HttpGet]
	public ActionResult Index() => View();
}