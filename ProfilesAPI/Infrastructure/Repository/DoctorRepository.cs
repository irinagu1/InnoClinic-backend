using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

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

    public async Task<PagedList<Doctor>> GetAllDoctorsAsync
        (DoctorParameters parameters, bool trackChanges)
    {
        var doctors =  await FindAll(trackChanges)
            .FilterDoctors(parameters.Status, parameters.Specialization, parameters.Office)
            .OrderBy( d => d.LastName)
            .Skip((parameters.PageNumber -1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();
        
        var count = await FindAll(trackChanges).CountAsync();

        var pagedList = PagedList<Doctor>.ToPagedList
            (doctors, parameters.PageNumber, parameters.PageSize);
        
        return pagedList;
    }
       
    public async Task<Doctor> GetDoctorByIdAsync(string doctorId, bool trackChanges) =>
        await FindByCondition(d => d.DoctorId.Equals(doctorId), trackChanges)
        .SingleOrDefaultAsync();
}