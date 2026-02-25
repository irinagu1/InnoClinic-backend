using RabbitMQ.Client;

namespace Intercommunication.RabbitMQ;

public interface IQueueChannelProvider<TQueueMessage>
{
   Task<IChannel> GetChannelAsync();
}