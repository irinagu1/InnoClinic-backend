using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProfilesApi;
using Repository;

namespace IntegrationTests.Fixtures;

public class WebApplicationFactoryFixture : IAsyncLifetime
{
    private const string _connectionString = 
        "Server=localhost,1433;Initial Catalog=ProfilesApiDbTest; User ID=sa;Password=12345iI!a;TrustServerCertificate=True;";
    
    private readonly WebApplicationFactory<AssemblyMarker> _factory;

    public HttpClient Client { get; private set; }
    
    public int InitialDoctorsCount { get; set; } = 5;

    public WebApplicationFactoryFixture()
    {
        _factory = new WebApplicationFactory<ProfilesApi.AssemblyMarker>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var descriptors = services.Where(d => 
                            d.ServiceType == typeof(DbContextOptions<RepositoryContext>) || 
                            d.ServiceType.Name.Contains("IDbContextOptionsConfiguration") ||
                            d.ServiceType == typeof(RepositoryContext))
                            .ToList();

                    foreach (var descriptor in descriptors)
                        services.Remove(descriptor);

                    services.AddDbContext<RepositoryContext>(opt =>
                    {
                        opt.UseSqlServer(_connectionString);
                    });
                });
            });

        Client = _factory.CreateClient();
    }

    public async Task InitializeAsync()
    {
        await using(var scope = _factory.Services.CreateAsyncScope())
        {
            var scoperServiceProvider = scope.ServiceProvider;
            var dbCont = scoperServiceProvider.GetRequiredService<RepositoryContext>();

            await dbCont.Database.EnsureCreatedAsync();
            await dbCont.Doctors!.AddRangeAsync(DataFixture.GetDoctors(InitialDoctorsCount));
            await dbCont.SaveChangesAsync();
        }
    }

    public async Task DisposeAsync()
    {
        await using(var scope = _factory.Services.CreateAsyncScope())
        {
            var scoperServiceProvider = scope.ServiceProvider;
            var dbCont = scoperServiceProvider.GetRequiredService<RepositoryContext>();

            await dbCont.Database.EnsureDeletedAsync();
        }
    }
}