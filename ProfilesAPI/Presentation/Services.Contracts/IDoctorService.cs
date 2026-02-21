using Shared.Dtos;

namespace Services.Contracts;

public interface IDoctorService
{
    Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync(bool trackChanges);
    Task<DoctorDto> GetDoctorByIdAsync(string doctorId, bool trackChanges);
    Task<DoctorDto> CreateDoctorAsync(DoctorForCreationDto dto);
}