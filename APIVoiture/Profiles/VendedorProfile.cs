using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;


namespace APIVoiture.Profiles
{
    public class VendedorProfile : Profile
    {
        public VendedorProfile()
        {
            CreateMap<Vendedor, UpdateVendedorDto>();
            CreateMap<CreateVendedorDto, Vendedor>();
            CreateMap<Vendedor, ReadVendedorDto>()
                 .ForMember(dto => dto.endereco, opt => opt.MapFrom(src => src.Endereco));
            CreateMap<UpdateVendedorDto, Vendedor>();
            CreateMap<Peca, ReadPecaDto>().ForMember(dest => dest.nomePeca, opt => opt.MapFrom(src => src.nomePeca))
            .ForMember(dest => dest.preco, opt => opt.MapFrom(src => src.preco))
            .ForMember(dest => dest.descricao, opt => opt.MapFrom(src => src.descricao))
            .ForMember(dest => dest.imagem, opt => opt.MapFrom(src => src.imagem)); ;
            CreateMap<Endereco, ReadEnderecoDto>();
        }
    }
}
