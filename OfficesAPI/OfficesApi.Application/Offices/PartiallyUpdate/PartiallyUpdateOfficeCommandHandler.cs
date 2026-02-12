using MediatR;
using OfficesApi.Application.Abstractions.Data;

namespace OfficesApi.Application.Offices.PartiallyUpdate;

public class PartiallyUpdateOfficeCommandHandler(IOfficeRepository officeRepository)
    : IRequestHandler<PartiallyUpdateOfficeCommand>
{
    public async Task Handle(PartiallyUpdateOfficeCommand request, CancellationToken cancellationToken)
    {
        //validate updates dictionary
        request.updates.Remove("_id");
        request.updates.Remove("Id");

        await officeRepository.PartiallyUpdateOffice(request.id, request.updates);
    }
}