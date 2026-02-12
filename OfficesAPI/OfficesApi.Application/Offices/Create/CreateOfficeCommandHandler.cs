using AutoMapper;
using MediatR;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Application.Offices.GetAll;
using OfficesApi.Domain;

namespace OfficesApi.Application.Offices.Create;

public class CreateOfficeCommandHandler(IOfficeRepository officeRepository, IMapper mapper)
     : IRequestHandler<CreateOfficeCommand, OfficeResponse>
{
    public async Task<OfficeResponse> Handle
        (CreateOfficeCommand request, CancellationToken cancellationToken)
    {
        var office = mapper.Map<Office>(request.OfficeCreateDto);

        await officeRepository.AddOfficeAsync(office);
        
        var officeResponse = mapper.Map<OfficeResponse>(office);

        return officeResponse;
    }
}