using Entities.Models;

namespace Contracts;

public interface IDoctorRepository
{
    IEnumerable<Doctor> GetAllDoctors(bool trackChanges);
}