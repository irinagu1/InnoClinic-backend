using AutoFixture;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using NSubstitute;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Application.Offices.Create;
using OfficesApi.Application.Offices.GetAll;
using OfficesApi.Domain;

namespace OfficesApi.Tests;

public class CreateOfficeCommandHandlerTests
{
    private readonly IOfficeRepository _officeRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<OfficeCreate> _validator;
    private readonly ILogger<CreateOfficeCommandHandler> _logger;

    private readonly CreateOfficeCommandHandler _handler;

    private readonly Fixture _fixture;
    public CreateOfficeCommandHandlerTests()
    {
        _fixture = new Fixture();
        _officeRepository = Substitute.For<IOfficeRepository>();
        _mapper = Substitute.For<IMapper>();
        _validator = Substitute.For<IValidator<OfficeCreate>>();
        _logger = Substitute.For<ILogger<CreateOfficeCommandHandler>>();

        _handler = new CreateOfficeCommandHandler(
            _officeRepository,
            _mapper,
            _validator,
            _logger
        );
    }

    [Fact]
    public async Task Handle_ValidRequest_ShouldCreateNewEntityAndReturnDto()
    {
        //Arrange
        var officeCreateDto = _fixture.Create<OfficeCreate>();
        var officeEntity = _fixture.Create<Office>();
        var offficeResponceDto = _fixture.Create<OfficeResponse>();

        var command = new CreateOfficeCommand(officeCreateDto);

        _mapper.Map<Office>(command.OfficeCreateDto).Returns(officeEntity);
        _mapper.Map<OfficeResponse>(officeEntity).Returns(offficeResponceDto);

        //Act
        var result = await _handler.Handle(command, default);

        //Assert
        result.Should().BeEquivalentTo(offficeResponceDto);
        await _officeRepository.Received(1).AddOfficeAsync(officeEntity);
    }

}