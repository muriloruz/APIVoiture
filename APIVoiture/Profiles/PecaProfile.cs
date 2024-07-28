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
                .ForMember(dest => dest.ModeloCarroValvulas, opt => opt.MapFrom(src => src.ModeloCarro.valvulas))
                .ForMember(dest => dest.ModeloCarroAno, opt => opt.MapFrom(src => src.ModeloCarro.ano))
                .ForMember(dest => dest.ModeloCarroModelo, opt => opt.MapFrom(src => src.ModeloCarro.modelo))
                .ForMember(dest => dest.ModeloCarroMarca, opt => opt.MapFrom(src => src.ModeloCarro.marca))
                .ForMember(dest => dest.ModeloCarroCambio, opt => opt.MapFrom(src => src.ModeloCarro.cambio))
                .ForMember(dest => dest.PagamentoStatus, opt => opt.MapFrom(src => src.Pagamento));
            CreateMap<CreatePecaDto, Peca>();
            CreateMap<UpdatePecaDto, Peca>();
        }
    }
    
}
