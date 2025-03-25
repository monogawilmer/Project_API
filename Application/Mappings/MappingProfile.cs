using AutoMapper;
using Project_API.Domain.DTOs;
using Project_API.Domain.Entities;

namespace Project_API.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Entity, DTO>()
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Rol, RolDTO>();
            CreateMap<TipoDocumento, TipoDocumentoDTO>();

            //CreateMap<DTO, Entity>()
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<RolDTO, Rol>();
            CreateMap<TipoDocumentoDTO, TipoDocumento>();
        }
    }
}
