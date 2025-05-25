using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;

namespace APIVoiture.Profiles
{
    public class PecaProfile : Profile
    {
        public PecaProfile() {
            CreateMap<Peca, ReadPecaDto>()
                .ForMember(dest => dest.VendedorEmail, opt => opt.MapFrom(src => src.Vendedor.UserName))
                .ForMember(dest => dest.VendedorTelefone, opt => opt.MapFrom(src => src.Vendedor.telefoneVend))
                .ForMember(dest => dest.VendedorNome, opt => opt.MapFrom(src => src.Vendedor.nome))
                .ForMember(dest => dest.PagamentoStatus, opt => opt.MapFrom(src => src.Pagamento));
            CreateMap<CreatePecaDto, Peca>();
            CreateMap<UpdatePecaDto, Peca>();
        }
    }
    
}
