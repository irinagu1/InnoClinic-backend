using Shared.Messaging;

namespace Services.Interfaces;

public interface IEventBus
{
    Task PublishAsync<T>(T @event, string routingKey, CancellationToken ct = default)
        where T : IntegrationEvent;

    void Subscribe<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>;

    void Unsubscribe<T, TH>()
        where TH : IIntegrationEventHandler<T>
        where T : IntegrationEvent;
}
