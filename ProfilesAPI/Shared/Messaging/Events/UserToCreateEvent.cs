namespace Shared.Messaging.Events;

public record UserToCreateEvent(string userType, string email, string userId)  
    : IntegrationEvent;
