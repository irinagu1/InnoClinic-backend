namespace OfficesApi.Shared;

public class MongoDbException : Exception
{
    public MongoDbException(string message)
        : base(message)
    {   
    }
}