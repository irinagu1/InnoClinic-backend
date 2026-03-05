using System.Net.Http.Json;
using FluentAssertions;
using IntegrationTests.Fixtures;
using Shared.Dtos;
using Shared.ResultPattern;

namespace IntegrationTests;

public class WithTestContainers : IClassFixture<DockerWebApplicationFactoryFixture>
{
    private readonly DockerWebApplicationFactoryFixture _factory;
    private readonly HttpClient _client;

    public WithTestContainers(DockerWebApplicationFactoryFixture factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }


    [Fact]
    public async Task OnGetDoctors_WhenExecuteApi_ShouldReturnExpectedDoctors()
    {
        //Arrange
    
        //Act
        var response = await _client.GetAsync(HttpHelper.GetAllDoctors);
        var result = await response.Content.ReadFromJsonAsync<List<DoctorDto>>();

         //Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        result.Count.Should().Be(_factory.InitialDoctorsCount);    
        result.Should()
            .BeEquivalentTo(DataFixture.GetDoctors
                (_factory.InitialDoctorsCount), opt =>
                    opt.ExcludingMissingMembers());
       
    }

    [Fact]
    public async Task OnGetDoctorById_WhenExecuteApi_ShouldReturnExpectedDoctor()
    {
        //Arrange
        var doctor = DataFixture.GetDoctor();
        var id = doctor.DoctorId;

        //Act
        var response = await _client.GetAsync(HttpHelper.DoctorWithId(id));
        var result = await response.Content.ReadFromJsonAsync<Result<DoctorDto>>();

         //Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        result!.Value.DoctorId.Should().Be(id);           
    }
}