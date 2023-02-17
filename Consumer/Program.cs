using Microsoft.AspNetCore.Builder;
using NServiceBus;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNServiceBus(_ =>
{
    var endpointConfiguration = new EndpointConfiguration("Consumer");
    endpointConfiguration.UseTransport<LearningTransport>();
     
    return endpointConfiguration;
});

var app = builder.Build();

app.Run();