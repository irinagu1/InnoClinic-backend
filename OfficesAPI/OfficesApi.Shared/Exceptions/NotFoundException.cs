namespace OfficesApi.Shared;

public class NotFoundException : Exception
{
    public NotFoundException(string id, string name)
        : base ($"Not found {name} with id " + id)
    {   
    }
}