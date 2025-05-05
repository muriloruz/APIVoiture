using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;

namespace APIVoiture.Profiles
{
    public class PecaProfile : Profile
    {
        public PecaProfile() {
            CreateMap<Peca, ReadPecaDto>()
                .ForMember(dest => dest.VendedorAvaliacao, opt => opt.MapFrom(src => src.Vendedor.avaliacao))
                .ForMember(dest => dest.PagamentoStatus, opt => opt.MapFrom(src => src.Pagamento));
            CreateMap<CreatePecaDto, Peca>();
            CreateMap<UpdatePecaDto, Peca>();
        }
    }
    
}
