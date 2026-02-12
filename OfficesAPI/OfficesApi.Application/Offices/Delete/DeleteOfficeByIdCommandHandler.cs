using MediatR;
using OfficesApi.Application.Abstractions.Data;

namespace OfficesApi.Application.Offices.Delete;

public class DeleteOfficeByIdCommandHandler(IOfficeRepository repository)
    : IRequestHandler<DeleteOfficeByIdCommand>
{
    public async Task Handle(DeleteOfficeByIdCommand request, CancellationToken cancellationToken)
    {
        //check if exists

        await repository.DeleteOfficeByIdAsync(request.id);
    }

}