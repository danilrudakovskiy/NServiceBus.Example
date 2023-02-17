using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using Producer;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNServiceBus(_ =>
{
    var endpointConfiguration = new EndpointConfiguration("Producer");
    var transport = endpointConfiguration.UseTransport<LearningTransport>();
    var routing = transport.Routing();
    routing.RouteToEndpoint(typeof(Ping), "Consumer");

    return endpointConfiguration;
});
builder.Host.ConfigureServices(services => { services.AddHostedService<PingSenderWorker>(); });

var app = builder.Build();

app.Run();