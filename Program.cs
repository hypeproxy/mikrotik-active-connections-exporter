using HypeProxy.PrometheusExporter.MikrotikActiveConnections.Services;
using HypeProxy.PrometheusExporter.MikrotikActiveConnections.Workers;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHealthChecks();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSingleton<MetricService>();
builder.Services.AddHostedService<UpdateMetricsWorker>();

var app = builder.Build();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapMetrics();
app.MapHealthChecks("/health");

app.Run();