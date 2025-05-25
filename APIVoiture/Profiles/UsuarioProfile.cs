using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;

namespace APIVoiture.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<UpdateUsuarioDto, Usuario>();
            CreateMap<Usuario, UpdateUsuarioDto>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<Usuario, ReadUsuarioDto>()
                .ForMember(dest => dest.Endereco,
                           opt => opt.MapFrom(src => src.Endereco));
        }
    }
}
