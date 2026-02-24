using IdentityServer.RabbitMQ.Events;

namespace RabbitMQ;

public interface IQueueConsumer<in TQueueMessage> 
    where TQueueMessage : IntegrationEvent
{
    Task ConsumeAsync(TQueueMessage message);
}