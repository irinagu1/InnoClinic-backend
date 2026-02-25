using RabbitMQ.Client;

namespace RabbitMQ;

public interface IQueueChannelProvider<TQueueMessage>
{
   Task<IChannel> GetChannelAsync();
}