using AutoMapper;
using MediatR;
using OfficesApi.Application.Abstractions.Data;
using OfficesApi.Application.Offices.GetAll;
using OfficesApi.Domain;
using OfficesApi.Shared;

namespace OfficesApi.Application.Offices.GetById;

public class GetOfficeByIdQueryHandler(IOfficeRepository officeRepository, IMapper mapper) 
    : IRequestHandler<GetOfficeByIdQuery, OfficeResponse>
{
    public async Task<OfficeResponse> Handle(GetOfficeByIdQuery request, CancellationToken cancellationToken)
    {
        Office OfficeEntity;
        try
        {
            OfficeEntity = await officeRepository.GetOfficeByIdAsync(request.id);

            if(OfficeEntity is null)
                throw new OfficeNotFoundException(request.id);
        }
        catch(Exception ex)
        {
            throw new MongoDbException(ex.Message);
        }
        
        var OfficeResponse = mapper.Map<OfficeResponse>(OfficeEntity);

        return OfficeResponse;
    }
}