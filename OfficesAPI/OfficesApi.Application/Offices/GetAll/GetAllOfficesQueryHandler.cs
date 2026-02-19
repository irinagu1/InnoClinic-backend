using AutoMapper;
using MediatR;
using OfficesApi.Application.Abstractions.Data;

namespace OfficesApi.Application.Offices.GetAll;

public class GetAllOfficesQueryHandler(IOfficeRepository officeRepository, IMapper mapper) 
    : IRequestHandler<GetAllOfficesQuery, IEnumerable<OfficeResponse>>
{
    
    public async Task<IEnumerable<OfficeResponse>> 
        Handle(GetAllOfficesQuery request, CancellationToken cancellationToken)
    {   
        var officesEntities = await officeRepository.GetAllOfficesAsync();

        var officesResponse = mapper.Map<IEnumerable<OfficeResponse>>(officesEntities);

        return officesResponse;
    }
}