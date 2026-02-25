using AutoMapper;
using Contracts;
using Entities.Models;
using FluentValidation;
using Services.AsyncCommunication;
using Services.Contracts;
using Shared;
using Shared.Dtos;
using Shared.Messaging.Events;
using Shared.ResultPattern;

namespace Services;

internal sealed class DoctorService : IDoctorService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<DoctorForCreationDto> _validator;
//    private readonly IEventBus _eventBus;
    private readonly IQueueProducer<UserToCreateEvent> _queueProducerUserToCreate;
    private readonly SynchronousCommunication _syncCommunication;

    public DoctorService(IRepositoryManager repositoryManager,
        IMapper mapper, IValidator<DoctorForCreationDto> validator, 
        IQueueProducer<UserToCreateEvent> queueProducerUserToCreate, SynchronousCommunication synchronousCommunication)
    {
        _repository = repositoryManager;
        _mapper = mapper;
        _validator = validator;
        _queueProducerUserToCreate = queueProducerUserToCreate;
        _syncCommunication = synchronousCommunication;
    }

    public async Task<Result<DoctorDto>> CreateDoctorAsync(DoctorForCreationDto dto)
    {
        await _validator.ValidateAndThrowAsync(dto);

        // 1 - check if email exists
        bool isEmailExiist = await _syncCommunication.CheckIfEmailIsExistAsync(dto.Email);
        if(isEmailExiist)
            return Result.Failure<DoctorDto>(AuthErrors.EmailAlreadyExist(dto.Email));

        var entity = _mapper.Map<Doctor>(dto);

        //2 set id and status - created and add to db
        entity.DoctorId = Guid.NewGuid().ToString();
        entity.EntityStatus = EntityStatuses.Created;

        _repository.Doctor.CreateDoctor(entity);
        
        await _repository.SaveAsync();
        
        //3 - change entity status and arise event
        entity.EntityStatus = EntityStatuses.Processing;
        await _repository.SaveAsync();

        var doctorCreatedEvent = new UserToCreateEvent(UserRoles.Doctor, dto.Email,  entity.DoctorId);
        await _queueProducerUserToCreate.PublishMessageAsync(doctorCreatedEvent);

        var dtoToReturn = _mapper.Map<DoctorDto>(entity);
        return Result.Success(dtoToReturn);
    }

    public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync(bool trackChanges)
    {
        var entities = await _repository.Doctor.GetAllDoctorsAsync(trackChanges);
        var dtos = _mapper.Map<IEnumerable<DoctorDto>>(entities);
        return dtos;
    }

    public async Task<Result<DoctorDto>> GetDoctorByIdAsync(string doctorId, bool trackChanges)
    {
        var entity = await _repository.Doctor.GetDoctorByIdAsync(doctorId, trackChanges);

        if(entity is null)
            return Result.Failure<DoctorDto>(DoctorErrors.NotFound(doctorId));

        var dto = _mapper.Map<DoctorDto>(entity);
 
        return Result.Success(dto);
    }

    public async Task<Result> DeleteDoctorByIdAsync(string doctorId, bool trackChanges)
    {
        var entity = await _repository.Doctor.GetDoctorByIdAsync(doctorId, trackChanges);

        if(entity is null)
            return Result.Failure<DoctorDto>(DoctorErrors.NotFound(doctorId));
        
        _repository.Doctor.DeleteDoctor(entity);

        await _repository.SaveAsync();
        
        return Result.Success();
    }
}