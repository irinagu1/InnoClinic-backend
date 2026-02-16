using AutoMapper;
using MediatR;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Domain;
using OfficesApi.Shared;

namespace OfficesApi.Application.Offices.GetAll;

public class GetAllOfficesQueryHandler(IOfficeRepository officeRepository, IMapper mapper) 
    : IRequestHandler<GetAllOfficesQuery, IEnumerable<OfficeResponse>>
{
    
    public async Task<IEnumerable<OfficeResponse>> 
        Handle(GetAllOfficesQuery request, CancellationToken cancellationToken)
    {   
        IEnumerable<Office> officesEntities;
        
        try
        {
            officesEntities = await officeRepository.GetAllOfficesAsync();
        }
        catch(Exception ex)
        {
            throw new MongoDbException(ex.Message);
        }
        
        var officesResponse = mapper.Map<IEnumerable<OfficeResponse>>(officesEntities);

        return officesResponse;
    }
}