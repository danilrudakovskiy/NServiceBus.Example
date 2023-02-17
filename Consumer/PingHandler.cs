using System;
using System.Threading.Tasks;
using Contracts;
using NServiceBus;

namespace Consumer;

public class PingHandler : IHandleMessages<Ping>
{
    public Task Handle(Ping message, IMessageHandlerContext context)
    {
        Console.WriteLine($"PING handled {message.Round}");
        Console.WriteLine($"PONG replied {message.Round}");
        
        var reply = new Pong { Acknowledgement = $"Message received {message.Round}" };
        
        return context.Reply(reply);
    }
}