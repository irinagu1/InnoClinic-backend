using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Shared;

public class HelperService : IHelperService
{
    public async Task CheckIfOfficeExistByIdAsync
        (IOfficeRepository officeRepository, string id)
    {
        var OfficeEntity = await officeRepository.GetOfficeByIdAsync(id);

            if(OfficeEntity is null)
                throw new NotFoundException(id, "office");
     
    }
}