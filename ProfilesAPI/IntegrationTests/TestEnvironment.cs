using System.Net.Http.Json;
using FluentAssertions;
using IntegrationTests.Fixtures;
using Shared.Dtos;
using Shared.ResultPattern;

namespace IntegrationTests;

public class TestEnvironment : IClassFixture<WebApplicationFactoryFixture> 
{
    private WebApplicationFactoryFixture _factory;

    public TestEnvironment(WebApplicationFactoryFixture factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task OnGetDoctors_WhenExecuteApi_ShouldReturnExpectedDoctors()
    {
        //Arrange
    
        //Act
        var response = await _factory.Client.GetAsync(HttpHelper.GetAllDoctors);
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
        var response = await _factory.Client.GetAsync(HttpHelper.DoctorWithId(id));
        var result = await response.Content.ReadFromJsonAsync<Result<DoctorDto>>();

         //Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        result!.Value.DoctorId.Should().Be(id);           
    }
}