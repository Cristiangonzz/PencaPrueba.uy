using AutoMapper;
using WordPenca.Common.Dto;

namespace WordPenca.Business.Domain
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Equipo, EquipoDTO>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.activo));// Mapeo de Equipo a EquipoDTO
            CreateMap<EquipoDTO, Equipo>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.activo));// Mapeo de Equipo a EquipoDTO
        }
    }
}
