using IdentityServer.RabbitMQ.Events;
using RabbitMQ.Client;

namespace RabbitMQ;

public class QueueChannelProvider<TQueueMessage> 
    : IQueueChannelProvider<TQueueMessage> 
      where TQueueMessage : IntegrationEvent
{
    private readonly IChannelProvider _channelProvider;
    private IChannel _channel;
    private readonly string _queueName;

    public QueueChannelProvider(IChannelProvider channelProvider)
    {
        _channelProvider = channelProvider;
        _queueName = typeof(TQueueMessage).Name;
    }

    public async Task<IChannel> GetChannelAsync()
    {
        _channel = await _channelProvider.GetChannelAsync();
        DeclareQueues();
        return _channel;
    }

    private void DeclareQueues()
    {   
        _channel.QueueDeclareAsync(
                    queue: _queueName, 
                    durable: true, 
                    exclusive: false, 
                    autoDelete: false, 
                    arguments: null).GetAwaiter().GetResult();
    }
}