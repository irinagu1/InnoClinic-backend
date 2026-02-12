using OfficesApi.Application.Offices.Create;
using OfficesApi.Domain;

namespace OfficesApi.Application.Abstractions.Data;

public interface IOfficeRepository
{ 
    Task<IEnumerable<Office>> GetAllOfficesAsync();
    Task<Office> GetOfficeByIdAsync(string id);
    Task AddOfficeAsync(Office office);
    Task DeleteOfficeByIdAsync(string id);
    Task PartiallyUpdateOffice(string id, Dictionary<string,object> updates);
}