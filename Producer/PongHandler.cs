using System;
using System.Threading.Tasks;
using Contracts;
using NServiceBus;

namespace Producer;

public class PongHandler : IHandleMessages<Pong>
{
    public Task Handle(Pong message, IMessageHandlerContext context)
    {
        Console.WriteLine($"PONG handled {message.Acknowledgement}");

        return Task.CompletedTask;
    }
}