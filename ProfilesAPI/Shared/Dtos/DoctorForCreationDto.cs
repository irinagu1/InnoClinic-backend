namespace Shared.Dtos;

public record DoctorForCreationDto(
    string Email,
    string FirstName,
    string LastName,
    string? MiddleName,
    DateOnly DateOfBirth,
    string SpecializationId,
    string OfficeId,
    int CareerStartYear,
    string Status
);