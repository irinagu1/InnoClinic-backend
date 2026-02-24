using Microsoft.Extensions.DependencyInjection;
using Services.Contracts;
using Shared.Messaging.Events;
using Shared.Messaging.Handlers;

namespace Services.AsyncCommunication.Handlers;

public class UserCreatedEventHandler : IIntegrationEventHandler<UserCreatedEvent>
{
    private readonly IServiceProvider _serviceProvider;
    private IUserService _userService;

    public UserCreatedEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task HandleAsync
        (UserCreatedEvent domainEvent, CancellationToken cancellationToken = default)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        _userService = scope.ServiceProvider.GetService<IUserService>();

        await _userService.UpdateUserAccountToReady(domainEvent);

        Console.WriteLine(@"[RabbitMQ] User created event from AutAPI handleled: {domainEvent}");
    }

}