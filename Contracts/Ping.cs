using NServiceBus;

namespace Contracts;

public class Ping : ICommand
{
    public int Round { get; init; }
}