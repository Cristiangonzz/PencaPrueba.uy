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

            CreateMap<ChatDTO, Chat>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.imagen, opt => opt.MapFrom(src => src.imagen));// Mapeo de ChatDTO a Chat
            CreateMap<Chat, ChatDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.imagen, opt => opt.MapFrom(src => src.imagen));// Mapeo de Chat a ChatDTO

            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));// Mapeo de Equipo a EquipoDTO
            CreateMap<Usuario, UsuarioDTO>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }

    }
}
