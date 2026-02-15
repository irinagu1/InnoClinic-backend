using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Application.Offices.GetAll;
using OfficesApi.Domain;
using OfficesApi.Shared;

namespace OfficesApi.Application.Offices.Create;

public class CreateOfficeCommandHandler
    (IOfficeRepository officeRepository, IMapper mapper, 
     IValidator<OfficeCreate> validator, ILogger<CreateOfficeCommandHandler> logger)
    : IRequestHandler<CreateOfficeCommand, OfficeResponse>
{
    public async Task<OfficeResponse> Handle
        (CreateOfficeCommand request, CancellationToken cancellationToken)
    {
        validator.ValidateAndThrow(request.OfficeCreateDto);

        var office = mapper.Map<Office>(request.OfficeCreateDto);
        
        try
        {
            await officeRepository.AddOfficeAsync(office);
            logger.LogInformation("Created new office object: {@Office}", office);         
        }
        catch(Exception ex)
        {
            logger.LogError("Exception occured when trying to create new office object: {@}", office);
            throw new MongoDbException(ex.Message);
        }
        
        var officeResponse = mapper.Map<OfficeResponse>(office);

        return officeResponse;
    }
}