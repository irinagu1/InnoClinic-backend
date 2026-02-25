using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
{
    public DoctorRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    {
    }

    public void CreateDoctor(Doctor doctor) =>
        Create(doctor);

    public void DeleteDoctor(Doctor doctor) =>
        Delete(doctor);

    public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .ToListAsync();

    public async Task<Doctor> GetDoctorByIdAsync(string doctorId, bool trackChanges) =>
        await FindByCondition(d => d.DoctorId.Equals(doctorId), trackChanges)
        .SingleOrDefaultAsync();
}