namespace IdentityServer.RabbitMQ.Events;

public record UserToCreateEvent(string userType, string email, string userId) : IntegrationEvent;