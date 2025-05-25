using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;

    public class PagamentoProfile : Profile
{
    public PagamentoProfile()
    {
        
        CreateMap<Pagamento, ReadPagamentoDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TipoPagamento, opt => opt.MapFrom(src => src.TipoPagamento))
            .ForMember(dest => dest.DataHora, opt => opt.MapFrom(src => src.DataHora))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.MetodoPagamento, opt => opt.MapFrom(src => src.MetodoPagamento))
            .ForMember(dest => dest.PrecoPeca, opt => opt.MapFrom(src => src.PrecoPeca))
            .ForMember(dest => dest.PecaId, opt => opt.MapFrom(src => src.PecaId))
            .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
            .ReverseMap();

       
        CreateMap<CreatePagamentoDto, Pagamento>()
            .ForMember(dest => dest.TipoPagamento, opt => opt.MapFrom(src => src.TipoPagamento))
            .ForMember(dest => dest.DataHora, opt => opt.MapFrom(src => src.DataHora))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.MetodoPagamento, opt => opt.MapFrom(src => src.MetodoPagamento))
            .ForMember(dest => dest.PrecoPeca, opt => opt.MapFrom(src => src.PrecoPeca))
            .ForMember(dest => dest.PecaId, opt => opt.MapFrom(src => src.PecaId))
            .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId));

       
        
    }
}
