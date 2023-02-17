using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Microsoft.Extensions.Hosting;
using NServiceBus;

namespace Producer;

public class PingSenderWorker : BackgroundService
{
    private readonly IMessageSession _messageSession;

    public PingSenderWorker(IMessageSession messageSession)
    {
        _messageSession = messageSession;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var round = 0;

        while (!stoppingToken.IsCancellationRequested)
        {
            await _messageSession.Send(new Ping { Round = round++ }, cancellationToken: stoppingToken)
                .ConfigureAwait(false);

            Console.WriteLine($"PING send {round}");

            await Task.Delay(10000, stoppingToken).ConfigureAwait(false);
        }
    }
}