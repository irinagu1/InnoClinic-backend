namespace Shared.Dtos;

public record DoctorDto(
    string DoctorId,
    string FirstName,
    string LastName,
    string? MiddleName,
    string FullName,
    DateOnly DateOfBirth,
    string SpecializationName,
    string OfficeAddress,
    int CareerStartYear,
    string Status,
    string EntityStatus
    );