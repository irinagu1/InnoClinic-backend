using OfficesApi.Application.Abstractions.Data;

public interface IHelperService
{
    Task CheckIfOfficeExistByIdAsync(IOfficeRepository officeRepository, string id);
}