using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using OfficesApi.Domain;

namespace OfficesApi.Infrastructure.MongoDb;

public static class MongoDbMapper
{
    public static void RegisterMappings()
    {
      //  BsonSerializer.RegisterSerializer(new StringSerializer(BsonType.ObjectId));

        BsonClassMap.RegisterClassMap<Office>(cm =>
        {
            cm.AutoMap(); 
            cm.MapIdField(u => u.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));
        });
    }
}