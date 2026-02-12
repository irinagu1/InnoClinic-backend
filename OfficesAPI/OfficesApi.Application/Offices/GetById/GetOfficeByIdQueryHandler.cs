using AutoMapper;
using MediatR;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Application.Offices.GetAll;

namespace OfficesApi.Application.Offices.GetById;

public class GetOfficeByIdQueryHandler(IOfficeRepository officeRepository, IMapper mapper) 
    : IRequestHandler<GetOfficeByIdQuery, OfficeResponse>
{
    public async Task<OfficeResponse> Handle(GetOfficeByIdQuery request, CancellationToken cancellationToken)
    {
        var officeEntity = await officeRepository.GetOfficeByIdAsync(request.id);

        if(officeEntity is null)
        { /*TODO: handle!!*/}

        var officeResponse = mapper.Map<OfficeResponse>(officeEntity);

        return officeResponse;
    }
}