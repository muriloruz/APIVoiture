using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;

public class VendedorClienteProfile : Profile
{
    public VendedorClienteProfile()
    {
        CreateMap<VendedorCliente, VendedorClienteDTO>()
            .ForMember(dest => dest.VendedorId, opt => opt.MapFrom(src => src.VendedorId))
            .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId));
    }
}