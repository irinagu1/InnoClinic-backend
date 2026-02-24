using IdentityServer.RabbitMQ.Events;

namespace RabbitMQ;

internal class QueueConsumerRegistratorService<TMessageConsumer, TQueueMessage> 
    : IHostedService where TMessageConsumer : IQueueConsumer<TQueueMessage> where TQueueMessage : IntegrationEvent
{
    private IQueueConsumerHandler<TMessageConsumer, TQueueMessage> _consumerHandler;
    private readonly IServiceProvider _serviceProvider;
    private IServiceScope _scope;

    public QueueConsumerRegistratorService(IServiceProvider serviceProvider)
    {

        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        // Every registration of a IQueueConsumerHandler will have its own scope
        // This will result in messages to the QueueConsumer will have their own incoming RabbitMQ channel
        _scope = _serviceProvider.CreateScope();

        _consumerHandler = _scope.ServiceProvider.GetRequiredService<IQueueConsumerHandler<TMessageConsumer, TQueueMessage>>();
        await _consumerHandler.RegisterQueueConsumerAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _scope.Dispose();

        return Task.CompletedTask;
    }
}