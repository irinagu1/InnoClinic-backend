namespace IdentityServer.RabbitMQ.Events;

public record UserCreatedEvent(string userType, string userId, string accountId) 
    : IntegrationEvent;