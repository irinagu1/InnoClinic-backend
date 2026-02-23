using IdentityServer.Db;
using IdentityServer.Models;
using IdentityServer.Services;
using IdentityServer.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        
        return services;    
    }

    public static IServiceCollection ConfigureDb
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IDbInitializer, DbInitializer>();
        
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }

    public static IServiceCollection ConfigureIdentityServer(this IServiceCollection services)
    {
        services.AddIdentityServer(opt =>
        {
            opt.Events.RaiseErrorEvents=true;
            opt.Events.RaiseInformationEvents=true;
            opt.Events.RaiseFailureEvents=true;
            opt.Events.RaiseSuccessEvents=true;
            opt.EmitStaticAudienceClaim=true;
        })
            .AddInMemoryIdentityResources(SD.IdentityResources)
            .AddInMemoryApiScopes(SD.ApiScopes())
            .AddInMemoryClients(SD.Clients())
            .AddAspNetIdentity<ApplicationUser>()
            .AddDeveloperSigningCredential()
            .AddProfileService<CustomProfileService>(); 
        
        return services;
    }

    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo{Title="Idetity Server AuthAPI", Version="v1"});
            });

        return services;
    }

}