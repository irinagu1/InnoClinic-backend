using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OfficesApi.Application.Abstractions.Data;

namespace OfficesApi.Infrastructure.MongoDb;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureMongoDb
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>
            (configuration.GetSection(MongoDbSettings.SectionName));

        MongoDbMapper.RegisterMappings();

        services.AddSingleton<IMongoClient>(sp =>
        {
            var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>();
            return new MongoClient(opt.Value.ConnectionString);
        });

        services.AddScoped(sp => 
        {
            var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>();
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(opt.Value.DatabaseName);
        });

        services.AddScoped<IOfficeRepository>(sp =>
        {
            var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>();
            var database = sp.GetRequiredService<IMongoDatabase>();
            return new OfficeRepository(database, opt.Value.CollectionName!); 
        });      
        
        return services;
    }
}