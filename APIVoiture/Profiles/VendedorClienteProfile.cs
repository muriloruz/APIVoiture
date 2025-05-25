using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;

public class VendedorClienteProfile : Profile
{
    public VendedorClienteProfile()
    {
        CreateMap<VendedorCliente, VendedorClienteDTO>()
            .ForMember(dest => dest.VendedorId, opt => opt.MapFrom(src => src.VendedorId))
            .ForMember(dest => dest.PecaId, opt => opt.MapFrom(src => src.PecaId))
            .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
            .ForMember(dest => dest.Vendedor, opt => opt.MapFrom(src => src.Vendedor))
            .ForMember(dest => dest.Peca, opt => opt.MapFrom(src => src.Peca))
            .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario));
        CreateMap<VendedorClienteDTO, VendedorCliente>()
            .ForMember(dest => dest.VendedorId, opt => opt.MapFrom(src => src.VendedorId))
            .ForMember(dest => dest.PecaId, opt => opt.MapFrom(src => src.PecaId))
            .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId));
        CreateMap<Vendedor, ReadVendedorDto>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.nome))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.telefoneVend, opt => opt.MapFrom(src => src.telefoneVend));
        CreateMap<Peca, ReadPecaDto>()
            .ForMember(dest => dest.nomePeca, opt => opt.MapFrom(src => src.nomePeca))
            .ForMember(dest => dest.preco, opt => opt.MapFrom(src => src.preco))
            .ForMember(dest => dest.descricao, opt => opt.MapFrom(src => src.descricao))
            .ForMember(dest => dest.imagem, opt => opt.MapFrom(src => src.imagem));
        CreateMap<Usuario, ReadUsuarioDto>()
            .ForMember(dest => dest.nome, opt => opt.MapFrom(src => src.nome))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
        CreateMap<VendedorCliente, ReadPecaDto>();
    }
}