using MediatR;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Shared;

namespace OfficesApi.Application.Offices.PartiallyUpdate;

public class PartiallyUpdateOfficeCommandHandler(IOfficeRepository officeRepository)
    : IRequestHandler<PartiallyUpdateOfficeCommand>
{
    public async Task Handle(PartiallyUpdateOfficeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await officeRepository.PartiallyUpdateOffice(request.id, request.updates);
        }
        catch(Exception ex)
        {
            throw new MongoDbException(ex.Message);
        }
    }
}