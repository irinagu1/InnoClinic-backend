using Application.Events;
using AutoMapper;
using Contracts;
using Entities.Models;
using FluentValidation;
using Services.Contracts;
using Services.Interfaces;
using Shared.Dtos;
using Shared.ResultPattern;

namespace Services;

internal sealed class DoctorService : IDoctorService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<DoctorForCreationDto> _validator;
    private readonly IEventBus _eventBus;

    private readonly SynchronousCommunication _syncCommunication;

    public DoctorService(IRepositoryManager repositoryManager,
        IMapper mapper, IValidator<DoctorForCreationDto> validator, 
        IEventBus eventBus, SynchronousCommunication synchronousCommunication)
    {
        _repository = repositoryManager;
        _mapper = mapper;
        _validator = validator;
        _eventBus = eventBus;
        _syncCommunication = synchronousCommunication;
    }

    public async Task<Result<DoctorDto>> CreateDoctorAsync(DoctorForCreationDto dto)
    {
        await _validator.ValidateAndThrowAsync(dto);

        bool isEmailExiist = await _syncCommunication.CheckIfEmailIsExistAsync(dto.Email);
        if(isEmailExiist)
            return Result.Failure<DoctorDto>(AuthErrors.EmailAlreadyExist(dto.Email));

        var entity = _mapper.Map<Doctor>(dto);
        _repository.Doctor.CreateDoctor(entity);
        await _repository.SaveAsync();
        var dtoToReturn = _mapper.Map<DoctorDto>(entity);
        
        return Result.Success(dtoToReturn);
    }

    public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync(bool trackChanges)
    {
     //   DoctorCreatedEvent e = new DoctorCreatedEvent("11", "emaol");
     //   await _eventBus.PublishAsync(e, "users");

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
}