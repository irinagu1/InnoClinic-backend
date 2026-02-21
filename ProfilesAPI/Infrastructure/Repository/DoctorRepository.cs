using Contracts;
using Entities.Models;

namespace Repository;

public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
{
    public DoctorRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    {
    }

    public IEnumerable<Doctor> GetAllDoctors(bool trackChanges) =>
        FindAll(trackChanges)
            .ToList();
}