using MediatR;
using Microsoft.Extensions.Logging;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Shared;

namespace OfficesApi.Application.Offices.PartiallyUpdate;

public class PartiallyUpdateOfficeCommandHandler(IOfficeRepository officeRepository, 
    ILogger<PartiallyUpdateOfficeCommandHandler> logger)
    : IRequestHandler<PartiallyUpdateOfficeCommand>
{
    public async Task Handle(PartiallyUpdateOfficeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await officeRepository.PartiallyUpdateOffice(request.id, request.updates);
            logger.LogInformation("Updated office object with Id {@Id}, updates array: {@Updates}", request.id, request.updates);
        }
        catch(Exception ex)
        {
            logger.LogError("Error occured when trying to update office object with Id {@Id}, updates array: {@Updates}", request.id, request.updates);
            throw new MongoDbException(ex.Message);
        }
    }
}