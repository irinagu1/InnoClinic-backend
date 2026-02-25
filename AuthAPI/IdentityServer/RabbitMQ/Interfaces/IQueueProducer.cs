using IdentityServer.RabbitMQ.Events;

namespace RabbitMQ.Interfaces;

public interface IQueueProducer<in TQueueMessage> 
    where TQueueMessage : IntegrationEvent
{
    Task PublishMessageAsync(TQueueMessage message);
}