using AutoMapper;
using OfficesApi.Application.Offices.Create;
using OfficesApi.Application.Offices.GetAll;
using OfficesApi.Domain;

namespace OfficesApi.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Office, OfficeResponse>()
            .ForMember(dest => dest.Address,
                    opt => opt.MapFrom(src => 
                    $"{src.City}, street {src.Street}, {src.HouseNumber}-{src.OfficeNumber}"));
        CreateMap<OfficeCreate, Office>();
    }
}