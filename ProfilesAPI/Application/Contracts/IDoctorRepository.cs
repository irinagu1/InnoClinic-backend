using Entities.Models;

namespace Contracts;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetAllDoctorsAsync(bool trackChanges);
    Task<Doctor> GetDoctorByIdAsync(string doctorId, bool trackChanges);
    void CreateDoctor(Doctor doctor);
}