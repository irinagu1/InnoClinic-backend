using Shared.Messaging.Events;

namespace Shared.Messaging.Handlers;

public interface IIntegrationEventHandler<in T> where T : IntegrationEvent
{
    Task HandleAsync(T domainEvent, CancellationToken cancellationToken = default);
}
