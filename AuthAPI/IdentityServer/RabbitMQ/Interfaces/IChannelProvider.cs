using RabbitMQ.Client;

namespace RabbitMQ;

public interface IChannelProvider
{
    Task<IChannel> GetChannelAsync();
}