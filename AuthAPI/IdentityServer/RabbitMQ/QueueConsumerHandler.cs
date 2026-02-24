using System.Text;
using System.Text.Json;
using IdentityServer.RabbitMQ.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ;

internal class QueueConsumerHandler<TMessageConsumer, TQueueMessage>    
    : IQueueConsumerHandler<TMessageConsumer, TQueueMessage> 
     where TMessageConsumer : IQueueConsumer<TQueueMessage> 
     where TQueueMessage : IntegrationEvent
{
    private readonly IServiceProvider _serviceProvider;
    private readonly string _queueName;
    private IChannel _consumerRegistrationChannel;
    private readonly string _consumerName;

    public QueueConsumerHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _queueName = "AuthAPI"; //typeof(TQueueMessage).Name;
        _consumerName = typeof(TMessageConsumer).Name;
    }

    public async Task RegisterQueueConsumerAsync()
    {
        var scope = _serviceProvider.CreateScope();

        // Request a channel for registering the Consumer for this Queue
        _consumerRegistrationChannel = await scope.ServiceProvider.GetRequiredService<IQueueChannelProvider<TQueueMessage>>().GetChannelAsync();

        var consumer = new AsyncEventingBasicConsumer(_consumerRegistrationChannel);

        // Register the trigger
        consumer.ReceivedAsync += HandleMessage;
        try
        {
            await _consumerRegistrationChannel.BasicConsumeAsync(_queueName, false, consumer);
        }
        catch (Exception ex)
        {
            var exMsg = $"BasicConsume failed for Queue '{_queueName}'";
            throw new Exception(exMsg);
        }
    }

    private async Task HandleMessage(object ch, BasicDeliverEventArgs ea)
    {
        // Create a new scope for handling the consumption of the queue message
        var consumerScope = _serviceProvider.CreateScope();

        // This is the channel on which the Queue message is delivered to the consumer
        var consumingChannel = ((AsyncEventingBasicConsumer)ch).Channel;

        IChannel producingChannel = null;
        try
        {
            // Within this processing scope, we will open a new channel that will handle all messages produced within this consumer/scope.
            // This is neccessairy to be able to commit them as a transaction
            producingChannel = await consumerScope.ServiceProvider.GetRequiredService<IChannelProvider>()
                .GetChannelAsync();

            // Serialize the message
            var message = DeserializeMessage(ea.Body.ToArray());

            // Enable transaction mode

            // Request an instance of the consumer from the Service Provider
            var consumerInstance = consumerScope.ServiceProvider.GetRequiredService<TMessageConsumer>();

            // Trigger the consumer to start processing the message
            await consumerInstance.ConsumeAsync(message);        
             
            Console.WriteLine($" [RabbitMQ] Received {message}");
                await ((AsyncEventingBasicConsumer)ch)
                .Channel.BasicAckAsync(ea.DeliveryTag, multiple: false);

        }
        catch (Exception ex)
        {
            var msg = $"Cannot handle consumption of a {_queueName} by {_consumerName}'";
            throw new Exception(msg);
        }
        finally
        {
            // Dispose the scope which ensures that all Channels that are created within the consumption process will be disposed
            consumerScope.Dispose();
        }
    }
    private static TQueueMessage DeserializeMessage(byte[] message)
    {
        var stringMessage = Encoding.UTF8.GetString(message);
        return JsonSerializer.Deserialize<TQueueMessage>(stringMessage);
    }
}