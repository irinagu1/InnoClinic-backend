using RabbitMQ.Client;

namespace Intercommunication.RabbitMQ;

public interface IChannelProvider
{
    Task<IChannel> GetChannelAsync();
}