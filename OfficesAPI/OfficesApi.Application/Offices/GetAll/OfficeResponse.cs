namespace OfficesApi.Application.Offices.GetAll;

public class OfficeResponse
{
    public string Id { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public string HouseNumber { get; init; }
    public string OfficeNumber { get; init; }
    public string RegistryPhoneNumber { get; init; }
    public string Address { get; init; }
    public bool IsActive { get; init; }

    public OfficeResponse()
    {
        
    }

  /*  public OfficeResponse(string id, string city, string street,
                         string houseNumber, string officeNumber, 
                         string registryPhoneNumber, bool isActive, string address)
    {
        
    }*/

}