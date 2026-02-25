using Microsoft.Extensions.DependencyInjection;
using Services.Contracts;
using Shared.Messaging.Events;

namespace Services.AsyncCommunication.Handlers;

public class UserCreatedEventHandler : IQueueConsumer<UserCreatedEvent>
{
    private readonly IServiceProvider _serviceProvider;
    private IServiceManager _serviceManager;

    public UserCreatedEventHandler(IServiceProvider serviceProvider)
    {

        _serviceProvider = serviceProvider;
    }

    public async Task ConsumeAsync(UserCreatedEvent domainEvent)
    {
        _serviceManager = _serviceProvider.GetService<IServiceManager>();
        var _userService = _serviceManager.UserService;
        
        await _userService.UpdateUserAccountToReady(domainEvent);

        Console.WriteLine(@"[RabbitMQ] User created event from AutAPI handleled: {domainEvent}");
    }

}