using IdentityServer.RabbitMQ.Events;

namespace IdentityServer.RabbitMQ.EventHandlers;

public interface IIntegrationEventHandler<in T> where T : IntegrationEvent
{
    Task HandleAsync(T domainEvent, CancellationToken cancellationToken = default);
}


