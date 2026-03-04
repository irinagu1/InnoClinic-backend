using System.Data.Common;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NSubstitute;
using OfficesApi.Application.Offices.GetAll;
using OfficesApi.Application.Offices.GetById;
using OfficesApi.Presentation.Controllers;

namespace OfficesApi.Tests;

public class OfficesControllerTests
{
    private readonly ISender _sender;
    private readonly OfficesController _controller;

    public OfficesControllerTests()
    {
        _sender  = Substitute.For<ISender>();
        _controller = new OfficesController(_sender);    
    }

    [Fact]
    public async Task GetOfficeById_WhenOfficeExists_ReturnsOk200()
    {
        //Arrange
        const string id = "1";
        var officeDto = new OfficeResponse() {Id = id};
        _sender.Send(Arg.Is<GetOfficeByIdQuery>( 
            q => q.id == id
        ))!.Returns(officeDto);

        //Act
        var result = await _controller.GetOfficeById(id);

        //Assert
        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().Be(officeDto);
    }
}