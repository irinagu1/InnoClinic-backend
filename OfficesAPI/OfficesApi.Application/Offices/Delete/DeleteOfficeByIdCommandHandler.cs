using MediatR;
using Microsoft.Extensions.Logging;
using OfficesApi.Application.Abstractions.Data;

namespace OfficesApi.Application.Offices.Delete;

public class DeleteOfficeByIdCommandHandler
    (IHelperService helperService, IOfficeRepository repository, 
    ILogger<DeleteOfficeByIdCommandHandler> logger)
    : IRequestHandler<DeleteOfficeByIdCommand>
{
    public async Task Handle(DeleteOfficeByIdCommand request, CancellationToken cancellationToken)
    {
        await helperService.CheckIfOfficeExistByIdAsync(repository, request.id);
        
        await repository.DeleteOfficeByIdAsync(request.id);
        
        logger.LogInformation("Deleted office object: {@Request}", request );         
    }
}