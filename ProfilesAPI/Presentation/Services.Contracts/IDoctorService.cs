using Shared.Dtos;
using Shared.RequestFeatures;
using Shared.ResultPattern;

namespace Services.Contracts;

public interface IDoctorService
{
    Task<(IEnumerable<DoctorDto> doctors, MetaData metaData)> 
        GetAllDoctorsAsync(DoctorParameters parameters, bool trackChanges);
    Task<Result<DoctorDto>> GetDoctorByIdAsync(string doctorId, bool trackChanges);
    Task<Result<DoctorDto>> CreateDoctorAsync(DoctorForCreationDto dto);
    Task<Result> DeleteDoctorByIdAsync(string doctorId, bool trackChanges);
}