using AutoMapper;
using Entities.Models;
using Shared.Dtos;

namespace ProfilesApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Doctor, DoctorDto>()
            .ForCtorParam("FullName", opt => opt.MapFrom(src => 
                        $"{src.LastName} {src.FirstName}"));

        CreateMap<DoctorForCreationDto, Doctor>();
    }
}