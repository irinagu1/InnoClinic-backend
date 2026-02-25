namespace Entities.Models;

public class Doctor
{
    public string DoctorId { get; set; } 
    public string? AccountId { get; set; } = null;
    
    public string EntityStatus { get; set; } 

    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string? MiddleName { get; set; } 

    public DateOnly DateOfBirth { get; set; }

    public string? SpecializationId { get; set; } 
    public string? SpecializationName { get; set; }

    public string? OfficeId { get; set; } 
    public string? OfficeAddress { get; set; } 
    
    public int CareerStartYear { get; set; }

    public string Status { get; set; }
}