using Duende.IdentityServer.Validation;
using IdentityServer.RabbitMQ.Events;
using IdentityServer.Services;
using RabbitMQ;

namespace IdentityServer.RabbitMQ.EventHandlers;

public class UserToCreateEventHandler : IQueueConsumer<UserToCreateEvent> //IIntegrationEventHandler<UserToCreateEvent>
{

    private IAuthService _authService;


    public UserToCreateEventHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task ConsumeAsync(UserToCreateEvent message)
    {
        await HandleAsync(message);
    }

    public async Task HandleAsync
        (UserToCreateEvent domainEvent, CancellationToken cancellationToken = default)
    {
        var accountId = await _authService.CreateNewAccountAndReturnIdAsync(domainEvent);

        Console.WriteLine(@"[RabbitMQ] Created new account event handleled: {domainEvent}");
        
        // TODO:  publish event rhat everyrthing is ok
       /* var userCreatedEvent = new UserCreatedEvent
            (domainEvent.userType, domainEvent.userId, accountId);
        await _eventBus.PublishAsync(userCreatedEvent, "AuthAPI");*/
    }

}