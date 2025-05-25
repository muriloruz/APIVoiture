using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;

namespace APIVoiture.Profiles
{
    public class FavoritoProfile : Profile
    {
        public FavoritoProfile() {
            CreateMap<Favorito, FavoritoDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PecaId, opt => opt.MapFrom(src => src.PecaId));
            CreateMap<FavoritoDTO, Favorito>();
            CreateMap<ReadFavDTO, Favorito>();
            CreateMap<Usuario, ReadUsuarioDto>();
            CreateMap<Favorito, ReadFavDTO>()
                .ForMember(dto => dto.user, opt => opt.MapFrom(u => new[] { u.User }))
                .ForMember(dto => dto.peca, opt => opt.MapFrom(p => new[] { p.Peca }));
                
        }

    }
}
