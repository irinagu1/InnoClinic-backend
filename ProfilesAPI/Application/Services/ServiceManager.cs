using AutoMapper;
using Contracts;
using FluentValidation;
using Services.Contracts;
using Services.Interfaces;
using Shared.Dtos;

namespace Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IDoctorService> _doctorService;

    public ServiceManager(
        IRepositoryManager repositoryManager, 
        IMapper mapper, 
        IValidator<DoctorForCreationDto> validator, 
        IEventBus eventBus,
        SynchronousCommunication synchronousCommunication)
    {
        _doctorService = new Lazy<IDoctorService>(()=> 
            new DoctorService(repositoryManager, mapper, validator, eventBus, synchronousCommunication));
    }

    public IDoctorService DoctorService => _doctorService.Value;
}