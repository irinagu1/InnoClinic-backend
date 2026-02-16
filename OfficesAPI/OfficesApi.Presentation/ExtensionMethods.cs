using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Infrastructure.MongoDb;
using OfficesApi.Presentation.Infrastructure.Poco;
using Serilog;

namespace OfficesApi.Presentation;

public static class ExtensionMethods
{
    public static IServiceCollection ConfigureMongoDb(this IServiceCollection services, 
    IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>
            (configuration.GetSection(MongoDbSettings.SectionName));


        MongoDbMapper.RegisterMappings();

        services.AddSingleton<IMongoClient>(sp =>
        {
            var opt = sp.GetRequiredService<IOptionsMonitor<MongoDbSettings>>();
            return new MongoClient(opt.CurrentValue.ConnectionString);
        });

        services.AddScoped(sp => 
        {
            var opt = sp.GetRequiredService<IOptionsSnapshot<MongoDbSettings>>();
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(opt.Value.DatabaseName);
        });

        services.AddScoped<IOfficeRepository>(sp =>
        {
            var opt = sp.GetRequiredService<IOptionsSnapshot<MongoDbSettings>>();
            var database = sp.GetRequiredService<IMongoDatabase>();
            return new OfficeRepository(database, opt.Value.CollectionName!); 
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