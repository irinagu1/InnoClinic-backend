using Shared.Messaging.Events;

namespace Services.Contracts;

public interface IUserService
{
    Task UpdateUserAccountToReady(UserCreatedEvent @event);
}