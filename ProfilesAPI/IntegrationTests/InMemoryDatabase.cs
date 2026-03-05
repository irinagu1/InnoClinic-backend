using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Repository;
using Services.AsyncCommunication;
using Shared.Dtos;
using Shared.Messaging.Events;
using Shared.ResultPattern;
using FluentAssertions;
using NSubstitute;
using ProfilesApi;
using IntegrationTests.Fixtures;

namespace IntegrationTests;

public class InMemoryDatabase
{
    private readonly WebApplicationFactory<AssemblyMarker> _factory;

    public InMemoryDatabase()
    {
         _factory = new WebApplicationFactory<ProfilesApi.AssemblyMarker>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    //SynchronousCommunication service mocking
                    var originalSynchronousCommunicationDescriptior =
                        services.SingleOrDefault(d => d.ServiceType == typeof(SynchronousCommunication));
                    
                    services.Remove(originalSynchronousCommunicationDescriptior!);

                    var syncCommServiceStub = Substitute.For<SynchronousCommunication>();

                    syncCommServiceStub.CheckIfEmailIsExistAsync(Arg.Any<string>())
                        .Returns(Task.FromResult(false));

                    services.AddTransient(_ => syncCommServiceStub);

                    //IQueueProducer service mocking
                    var originalQueueProducer = services.SingleOrDefault(
                        s => s.ServiceType == typeof(IQueueProducer<UserToCreateEvent>));

                    services.Remove(originalQueueProducer!);

                    var queueProducerServiceStub = 
                        Substitute.For<IQueueProducer<UserToCreateEvent>>();

                    queueProducerServiceStub.PublishMessageAsync(Arg.Any<UserToCreateEvent>())
                        .Returns(Task.CompletedTask);

                    services.AddScoped(_=> queueProducerServiceStub); 

                    //Db services               
                    var descriptors = services.Where(d => 
                            d.ServiceType == typeof(DbContextOptions<RepositoryContext>) || 
                            d.ServiceType.Name.Contains("IDbContextOptionsConfiguration") ||
                            d.ServiceType == typeof(RepositoryContext))
                            .ToList();

                    foreach (var descriptor in descriptors)
                        services.Remove(descriptor);

                    services.AddDbContext<RepositoryContext>(opt =>
                    {
                        opt.UseInMemoryDatabase("test");
                    });
                });
            });
    }

    [Fact]
    public async Task OnGetDoctors_WhenExecuteApi_ShouldReturnExpectedDoctor()
    {
        //Arrange
        using(var scope = _factory.Services.CreateScope())
        {
            var scopeService = scope.ServiceProvider;
            var dbContext = scopeService.GetRequiredService<RepositoryContext>();
            
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var doctor = DataFixture.GetDoctor();
            dbContext.Doctors!.Add(doctor);
            dbContext.SaveChanges();
        }

        var client = _factory.CreateClient();

        //Act
        var response = await client.GetAsync(HttpHelper.GetAllDoctors);
        var result = await response.Content.ReadFromJsonAsync<List<DoctorDto>>();
        
        //Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        result!.Count.Should().Be(1);
        result.Should()
            .BeEquivalentTo([DataFixture.GetDoctor()], 
                opt => opt.ExcludingMissingMembers());   
    }


    [Fact]
    public async Task OnAddDoctor_WhenExecuteApi_ShouldReturnExpectedDoctor()
    {
        //Arrange
        using(var scope = _factory.Services.CreateScope())
        {
            var scopeService = scope.ServiceProvider;
            var dbContext = scopeService.GetRequiredService<RepositoryContext>();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            dbContext.SaveChanges();

        }

       var client = _factory.CreateClient();
       const string Name = "Anna";
       var doctor = new DoctorForCreationDto(
            "mymail@mail.ru",
            Name,
            "Ivanova",
            "Ivanovna",
            new DateOnly(2020,1,1),
            "2",
            "2",
            2022,
            "At work"
        );

        var httpContent = new StringContent(JsonConvert.SerializeObject(doctor), Encoding.UTF8, "application/json");
        
        //Act
        var response = await client.PostAsync(HttpHelper.GetAllDoctors, httpContent);
        var result = await response.Content.ReadFromJsonAsync<Result<DoctorDto>>();
        
        //Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        result!.Value.FirstName.Should().Be(Name);
    }
       
}
 