using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using Services.AsyncCommunication;
using Shared.Messaging.Events;

namespace Intercommunication.RabbitMQ;

public class QueueProducer<TQueueMessage> 
    : IQueueProducer<TQueueMessage> 
      where TQueueMessage : IntegrationEvent
{
    private readonly string _queueName;
    private readonly IChannel _channel;

    public QueueProducer(IQueueChannelProvider<TQueueMessage> channelProvider)
    {
        _channel = channelProvider.GetChannelAsync().GetAwaiter().GetResult();
        _queueName =  typeof(TQueueMessage).Name;
    }

    public async Task PublishMessageAsync(TQueueMessage @event)
    {
        if (Equals(@event, default(TQueueMessage))) throw new ArgumentNullException(nameof(@event));
         
        var body = SerializeMessage(@event);
            
        await _channel.BasicPublishAsync(    
            exchange: string.Empty,
            routingKey: _queueName,
            mandatory: true, 
            basicProperties: new BasicProperties { Persistent = true }, 
            body: body);
    }

    private static byte[] SerializeMessage(TQueueMessage message)
    {
        var stringContent = JsonSerializer.Serialize(message);
        return Encoding.UTF8.GetBytes(stringContent);
    }
  }