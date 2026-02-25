using IdentityServer.RabbitMQ.Events;
using IdentityServer.Services;
using RabbitMQ;
using RabbitMQ.Interfaces;

namespace IdentityServer.RabbitMQ.EventHandlers;

public class UserToCreateEventHandler : IQueueConsumer<UserToCreateEvent> 
{
    private IAuthService _authService;
    private IQueueProducer<UserCreatedEvent> _queueProducerUserCreated;

    public UserToCreateEventHandler
        (IAuthService authService, 
         IQueueProducer<UserCreatedEvent> queueProducerUserCreated)
    {
        _authService = authService;
        _queueProducerUserCreated = queueProducerUserCreated;
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

        var userCreatedEvent = new UserCreatedEvent
            (domainEvent.userType, domainEvent.userId, accountId);
        await _queueProducerUserCreated.PublishMessageAsync(userCreatedEvent);
    }

}