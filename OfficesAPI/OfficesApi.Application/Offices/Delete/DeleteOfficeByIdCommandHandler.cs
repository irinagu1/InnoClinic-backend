using MediatR;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Shared;

namespace OfficesApi.Application.Offices.Delete;

public class DeleteOfficeByIdCommandHandler(IOfficeRepository repository)
    : IRequestHandler<DeleteOfficeByIdCommand>
{
    public async Task Handle(DeleteOfficeByIdCommand request, CancellationToken cancellationToken)
    {
        await CheckIfOfficeExistByIdAsync(request.id);
        
        try
        {
            await repository.DeleteOfficeByIdAsync(request.id);
        }
        catch(Exception ex)
        {
            throw new MongoDbException(ex.Message, ex);
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