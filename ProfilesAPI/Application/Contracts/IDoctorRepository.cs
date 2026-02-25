using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IDoctorRepository
{
    Task<PagedList<Doctor>> GetAllDoctorsAsync(DoctorParameters parameters, bool trackChanges);
    Task<Doctor> GetDoctorByIdAsync(string doctorId, bool trackChanges);
    void CreateDoctor(Doctor doctor);
    void DeleteDoctor(Doctor doctor);
}