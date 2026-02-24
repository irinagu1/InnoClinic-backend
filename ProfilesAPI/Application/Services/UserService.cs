using Contracts;
using Services.Contracts;
using Shared;
using Shared.Exceptions.RabbitMQ;
using Shared.Messaging.Events;

namespace Services;

internal sealed class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;

    public UserService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task UpdateUserAccountToReady(UserCreatedEvent @event)
    {
        switch(@event.userType)
        {
            case UserRoles.Doctor:
                await UpdateDoctorToReady(@event.userId, @event.accountId);
                break;
            default:
                throw new RabbitMQException(
                       RabbitMQExceptionTypes.InvalidUserRoleReceived,
                        $"Such type of user is not valid: {@event.userType}");
        }
    }

    private async Task UpdateDoctorToReady
        (string doctorId, string accountId)
    {
        var doctorEntity = await _repositoryManager.Doctor.GetDoctorByIdAsync(doctorId, true);
        if(doctorEntity is null)
            throw new RabbitMQException
                (RabbitMQExceptionTypes.InvalidUserIdReceived,
                 $"Cant find doctor with id which we get from rabbitmq authapi {doctorId}");

        doctorEntity.AccountId = accountId;
        doctorEntity.EntityStatus = EntityStatuses.Ready;

        await _repositoryManager.SaveAsync();
    }

}