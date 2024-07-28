using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;

namespace APIVoiture.Profiles
{
    public class PagamentoProfile : Profile
    {
        public PagamentoProfile()
        {
            CreateMap<Pagamento, ReadPagamentoDto>();
            CreateMap<CreatePagamentoDto, Pagamento>();
            CreateMap<UpdatePagamentoDto, Pagamento>();
        }
    }
}
