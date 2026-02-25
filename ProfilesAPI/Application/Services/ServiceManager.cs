using AutoMapper;
using Contracts;
using FluentValidation;
using Services.AsyncCommunication;
using Services.Contracts;
using Shared.Dtos;
using Shared.Messaging.Events;

namespace Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IDoctorService> _doctorService;
    private readonly Lazy<IUserService> _userService;

    public ServiceManager(
        IRepositoryManager repositoryManager, 
        IMapper mapper, 
        IValidator<DoctorForCreationDto> validator, 
       IQueueProducer<UserToCreateEvent> queueProducerUserToCreate,
        SynchronousCommunication synchronousCommunication)
    {
        _doctorService = new Lazy<IDoctorService>(()=> 
            new DoctorService(repositoryManager, mapper, validator, queueProducerUserToCreate, synchronousCommunication));
        
        _userService = new Lazy<IUserService>(() => new UserService(repositoryManager));
    }

    public IDoctorService DoctorService => _doctorService.Value;
    public IUserService UserService => _userService.Value;
}