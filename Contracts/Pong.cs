using NServiceBus;

namespace Contracts;

public class Pong : IMessage
{
    public string Acknowledgement { get; init; }
}