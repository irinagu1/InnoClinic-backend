using AutoMapper;
using Contracts;
using Entities.Models;
using FluentValidation;
using Services.Contracts;
using Shared.Dtos;
using Shared.ResultPattern;

namespace Services;

internal sealed class DoctorService : IDoctorService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<DoctorForCreationDto> _validator;

    public DoctorService(IRepositoryManager repositoryManager,
        IMapper mapper, IValidator<DoctorForCreationDto> validator)
    {
        _repository = repositoryManager;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<DoctorDto> CreateDoctorAsync(DoctorForCreationDto dto)
    {
        await _validator.ValidateAndThrowAsync(dto);
        
        var entity = _mapper.Map<Doctor>(dto);
        _repository.Doctor.CreateDoctor(entity);
        await _repository.SaveAsync();
        var dtoToReturn = _mapper.Map<DoctorDto>(entity);
        return dtoToReturn;
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
}