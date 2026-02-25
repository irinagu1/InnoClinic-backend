namespace Intercommunication.RabbitMQ;

public interface IQueueConsumerHandler<TMessageConsumer, TQueueMessage> 
{
    Task RegisterQueueConsumerAsync();
}