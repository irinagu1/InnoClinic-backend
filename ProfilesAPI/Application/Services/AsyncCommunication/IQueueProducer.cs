using Shared.Messaging.Events;

namespace Services.AsyncCommunication;

public interface IQueueProducer<in TQueueMessage> 
    where TQueueMessage : IntegrationEvent
{
    Task PublishMessageAsync(TQueueMessage message);
}