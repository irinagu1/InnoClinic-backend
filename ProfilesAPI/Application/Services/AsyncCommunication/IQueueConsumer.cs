using Shared.Messaging.Events;

namespace Services.AsyncCommunication;
public interface IQueueConsumer<in TQueueMessage> 
    where TQueueMessage : IntegrationEvent
{
    Task ConsumeAsync(TQueueMessage message);
}