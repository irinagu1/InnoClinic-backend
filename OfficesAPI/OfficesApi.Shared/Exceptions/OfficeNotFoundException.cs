namespace OfficesApi.Shared;

public class OfficeNotFoundException : MongoDbException
{
    public OfficeNotFoundException(string id)
        : base ("Not found office with id " + id)
    {   
    }
}