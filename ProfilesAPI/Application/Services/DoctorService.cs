using AutoMapper;
using Contracts;
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

    public IEnumerable<DoctorDto> GetAllDoctors(bool trackChanges)
    {
        var entities = _repository.Doctor.GetAllDoctors(trackChanges);
        var dtos = _mapper.Map<IEnumerable<DoctorDto>>(entities);
        return dtos;
    }
}