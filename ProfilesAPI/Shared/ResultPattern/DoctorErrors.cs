namespace Shared.ResultPattern;

public static class DoctorErrors
{
    public static Error NotFound(string doctorId) =>
        new Error("Doctor.NotFound", $"The doctor with id: {doctorId} was not found");
}
