using IdentityServer.RabbitMQ.Events;

namespace IdentityServer.Services;

public interface IAuthService
{
    Task<bool> CheckIfEmailExistsAsync(string email);
    Task<string> CreateNewAccountAndReturnIdAsync(UserToCreateEvent @event);
}