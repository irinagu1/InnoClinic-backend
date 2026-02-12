using System.Text.Json;
using MongoDB.Driver;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Domain;

namespace OfficesApi.Infrastructure.MongoDb;

public class OfficeRepository : IOfficeRepository
{
    private readonly IMongoCollection<Office> _officeCollection;

    public OfficeRepository(IMongoDatabase database, string collectionName)
    {
        _officeCollection = database.GetCollection<Office>(collectionName);
    }

    public async Task AddOfficeAsync(Office office) =>
        await _officeCollection.InsertOneAsync(office);

    public async Task<IEnumerable<Office>> GetAllOfficesAsync() =>
        await _officeCollection.Find(_ => true).ToListAsync();

    public async Task<Office> GetOfficeByIdAsync(string id) =>
        await _officeCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task DeleteOfficeByIdAsync(string id) =>
        await _officeCollection.DeleteOneAsync(x=> x.Id == id);

    public async Task PartiallyUpdateOffice(string id, Dictionary<string, object> updates)
    {
        var updatesDefinition = updates.Select(f => 
        {
            object val = f.Value;

            if(val is JsonElement el)
                val = ConvertJsonElement(el);

            return Builders<Office>.Update.Set(f.Key, val);
        });
        var combinedUpdates = Builders<Office>.Update.Combine(updatesDefinition);

        await _officeCollection.UpdateOneAsync(of => of.Id == id, combinedUpdates);
    }

    private static object ConvertJsonElement(JsonElement element)
{
    return element.ValueKind switch
    {
        JsonValueKind.String => element.GetString(),
        JsonValueKind.Number => element.TryGetInt64(out var l) ? l : element.GetDouble(),
        JsonValueKind.True => true,
        JsonValueKind.False => false,
        JsonValueKind.Null => null,
        _ => element.GetRawText() 
    };
}
}
