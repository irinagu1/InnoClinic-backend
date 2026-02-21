using AutoMapper;
using Contracts;
using Entities.Models;
using Services.Contracts;
using Shared.Dtos;

namespace Services;

internal sealed class DoctorService : IDoctorService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public DoctorService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repository = repositoryManager;
        _mapper = mapper;
    }

    public async Task<DoctorDto> CreateDoctorAsync(DoctorForCreationDto dto)
    {
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

    public async Task<DoctorDto> GetDoctorByIdAsync(string doctorId, bool trackChanges)
    {
        var entity = await _repository.Doctor.GetDoctorByIdAsync(doctorId, trackChanges);

         // NULL CHECK

        var dto = _mapper.Map<DoctorDto>(entity);
        return dto;
    }
}