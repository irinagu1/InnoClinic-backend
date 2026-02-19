namespace OfficesApi.Infrastructure.MongoDb;

public class MongoDbSettings
{
    public const string SectionName = "MongoDbSettings";
    public string? ConnectionString {get;set;}
    public string? DatabaseName {get;set;}
    public string? CollectionName {get;set;}
}