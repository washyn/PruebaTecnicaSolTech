using AutoMapper;
using Washyn.TechTest.Entities;
using Washyn.TechTest.Services;
using Washyn.TechTest.Services.Dto;

namespace Washyn.TechTest.Others.ObjectMapping;

public class ProjectAutoMapperProfile : Profile
{
    public ProjectAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */
        CreateMap<Usuario, UsuarioDto>()
            .ReverseMap();
        
        CreateMap<Usuario, UsuarioCreateDto>()
            .ReverseMap();
        
        CreateMap<Usuario, UsuarioUpdateDto>()
            .ReverseMap();
    }
}
