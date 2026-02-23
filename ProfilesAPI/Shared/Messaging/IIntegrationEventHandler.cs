namespace Shared.Messaging;


public interface IIntegrationEventHandler<in T> where T : IntegrationEvent
{
    Task Handle(T domainEvent, CancellationToken cancellationToken);
}
