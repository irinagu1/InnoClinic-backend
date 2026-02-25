using Shared.Dtos;
using Shared.ResultPattern;

namespace Services.Contracts;

public interface IDoctorService
{
    Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync(bool trackChanges);
    Task<Result<DoctorDto>> GetDoctorByIdAsync(string doctorId, bool trackChanges);
    Task<Result<DoctorDto>> CreateDoctorAsync(DoctorForCreationDto dto);
    Task<Result> DeleteDoctorByIdAsync(string doctorId, bool trackChanges);
}