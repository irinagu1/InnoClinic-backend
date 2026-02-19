using MediatR;
using Microsoft.Extensions.Logging;
using OfficesApi.Application.Abstractions.Data;

namespace OfficesApi.Application.Offices.PartiallyUpdate;

public class PartiallyUpdateOfficeCommandHandler
    (IHelperService helperService,
    IOfficeRepository officeRepository, 
    ILogger<PartiallyUpdateOfficeCommandHandler> logger)
    : IRequestHandler<PartiallyUpdateOfficeCommand>
{
    public async Task Handle
        (PartiallyUpdateOfficeCommand request, CancellationToken cancellationToken)
    {
        await helperService.CheckIfOfficeExistByIdAsync(officeRepository, request.id);
        await officeRepository.PartiallyUpdateOffice(request.id, request.updates);
        logger.LogInformation("Updated office object with Id {@Id}, updates array: {@Updates}", request.id, request.updates);
    }
}