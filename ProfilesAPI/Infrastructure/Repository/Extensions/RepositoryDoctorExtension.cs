
using Entities.Models;

namespace Repository.Extensions;

public static class RepositoryDoctorExtension
{
    public static IQueryable<Doctor> FilterDoctors
        (this IQueryable<Doctor> doctors, 
        string status, string specialization, string office)
    {
        if(status is not null)
            doctors = doctors.Where(d => d.Status.Equals(status));
        
        if(specialization is not null)
            doctors = doctors.Where(d => d.SpecializationName!.Equals(specialization));

        if(office is not null)
            doctors = doctors.Where(d => d.OfficeAddress!.Equals(office));
        
        return doctors;
    }
}