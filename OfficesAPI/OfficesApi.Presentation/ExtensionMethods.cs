using MongoDB.Driver;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Infrastructure.MongoDb;
using Serilog;

namespace OfficesApi.Presentation;

public static class ExtensionMethods
{
    public static IServiceCollection ConfigureMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoSettings = configuration.GetSection("MongoDbSettings");
        var connectionString = mongoSettings["ConnectionString"];
        var databaseName = mongoSettings["DatabaseName"];
        var collectionName = mongoSettings["CollectionName"];

        MongoDbMapper.RegisterMappings();

        services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
        services.AddScoped(sp => 
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(databaseName);
        });

        services.AddScoped<IOfficeRepository>(sp =>
        {
            var database = sp.GetRequiredService<IMongoDatabase>();
            return new OfficeRepository(database, collectionName); 
        });      
        
        return services;
    }

    public static IServiceCollection ConfigureExceptionHandlers(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddExceptionHandler<MongoDbExceptionHandler>();

        return services;    
    }

    public static IHostBuilder ConfigureLogging(this IHostBuilder host)
    {
        string customTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] [{CorrelationId}] {Message:lj}{NewLine}{Exception}";

        host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()  
            .WriteTo.Console(outputTemplate: customTemplate)
            .WriteTo.File(
                path: "logs/log-officesApi-.txt", 
                rollingInterval: RollingInterval.Day,
                outputTemplate: customTemplate,
                shared: true) 
            );
        return host;
    }
}