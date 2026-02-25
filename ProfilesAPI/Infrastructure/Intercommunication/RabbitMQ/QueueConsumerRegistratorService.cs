using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.AsyncCommunication;
using Shared.Messaging.Events;

namespace Intercommunication.RabbitMQ;

public class QueueConsumerRegistratorService<TMessageConsumer, TQueueMessage> 
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