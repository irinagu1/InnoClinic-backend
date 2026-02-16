using MediatR;
using Microsoft.Extensions.Logging;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Shared;

namespace OfficesApi.Application.Offices.Delete;

public class DeleteOfficeByIdCommandHandler
    (IOfficeRepository repository, ILogger<DeleteOfficeByIdCommandHandler> logger)
    : IRequestHandler<DeleteOfficeByIdCommand>
{
    public async Task Handle(DeleteOfficeByIdCommand request, CancellationToken cancellationToken)
    {
        await CheckIfOfficeExistByIdAsync(request.id);
        
        try
        {
            await repository.DeleteOfficeByIdAsync(request.id);
            logger.LogInformation("Deleted office object: {@Request}", request );         
        }
        catch(Exception ex)
        {
            logger.LogError("Exception occured when trying to delete office object: {@Request}", request);
            throw new MongoDbException(ex.Message);
        }
    }

    private async Task CheckIfOfficeExistByIdAsync(string id)
    {
        var result = await repository.GetOfficeByIdAsync(id);
        if(result is null)
        {
            System.Console.WriteLine("test");
            throw new OfficeNotFoundException(id);
        }
    }
}