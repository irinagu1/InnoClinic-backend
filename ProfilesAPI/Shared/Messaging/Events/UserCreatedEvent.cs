namespace Shared.Messaging.Events;

public record UserCreatedEvent(string userType, string userId, string accountId) 
    : IntegrationEvent;