namespace RabbitMQ;

public interface IQueueConsumerHandler<TMessageConsumer, TQueueMessage> 
{
    Task RegisterQueueConsumerAsync();
}