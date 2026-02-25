namespace Shared.RequestFeatures;

public class DoctorParameters : RequestParameters
{
    public string? Status { get; set; } = UserStatuses.AtWork;
    public string? Specialization { get; set; }
    public string? Office { get; set; } 

}