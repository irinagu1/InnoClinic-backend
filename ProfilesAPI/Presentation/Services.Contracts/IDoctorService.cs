using Shared.Dtos;

namespace Services.Contracts;

public interface IDoctorService
{
    IEnumerable<DoctorDto> GetAllDoctors(bool trackChanges);
}