using AutoMapper;
using MediatR;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Application.Offices.GetAll;
using OfficesApi.Shared;

namespace OfficesApi.Application.Offices.GetById;

public class GetOfficeByIdQueryHandler
    (IOfficeRepository officeRepository, IMapper mapper) 
    : IRequestHandler<GetOfficeByIdQuery, OfficeResponse>
{
    public async Task<OfficeResponse> Handle
        (GetOfficeByIdQuery request, CancellationToken cancellationToken)
    {
        var OfficeEntity = await officeRepository.GetOfficeByIdAsync(request.id);

            if(OfficeEntity is null)
                throw new NotFoundException(request.id, "office");
     
        var OfficeResponse = mapper.Map<OfficeResponse>(OfficeEntity);

        return OfficeResponse;
    }
}