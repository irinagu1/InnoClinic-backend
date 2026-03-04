using AutoMapper;
using FluentAssertions;
using NSubstitute;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Application.Offices.GetAll;
using OfficesApi.Application.Offices.GetById;
using OfficesApi.Domain;
using OfficesApi.Shared;

namespace OfficesApi.Tests;

public class GetOfficeByIdQueryHandlerTests
{
    private readonly GetOfficeByIdQueryHandler _handler;
    private readonly IOfficeRepository _officeRepository;
    private readonly IMapper _mapper;

    public GetOfficeByIdQueryHandlerTests()
    {
        _officeRepository = Substitute.For<IOfficeRepository>();
        _mapper = Substitute.For<IMapper>();

        _handler = new GetOfficeByIdQueryHandler(
            _officeRepository,
            _mapper
        );
    }

    [Fact]
    public async Task Handle_WhenOfficeExist_ShouldReturnOfficeResponse()
    {
        //Arrange
        var id = "1";
        var officeEntity = new Office() { Id = id };
        var OfficeResponseDto = new OfficeResponse() { Id = id };

        var query = new GetOfficeByIdQuery(id);
        _officeRepository.GetOfficeByIdAsync(id)!.Returns(officeEntity);
        _mapper.Map<OfficeResponse>(officeEntity).Returns(OfficeResponseDto);

        //Act
        var result = await _handler.Handle(query, cancellationToken: default);
        
        //Assert    
        result.Should().NotBeNull();
        result.Id.Should().Be(id);
    }
    
    [Fact]
    public async Task Handle_WhenOfficeDoesNotExist_ShouldReturnNotFoundException()
    {
        //Arrange
        var id = "1";
        var query = new GetOfficeByIdQuery(id);
        _officeRepository.GetOfficeByIdAsync(id)!.Returns((Office?)null);

        //Act
        var act = () => _handler.Handle(query, cancellationToken: default);
        
        //Assert    
        await act.Should().ThrowAsync<NotFoundException>();
    }
}

//dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./coverage.cobertura.xml
//reportgenerator -reports:./coverage.cobertura.xml -targetdir:./coverage_report_html -reporttypes:Html
