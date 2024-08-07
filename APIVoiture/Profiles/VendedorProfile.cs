using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;


namespace APIVoiture.Profiles
{
    public class VendedorProfile : Profile
    {
        public VendedorProfile()
        {
            CreateMap<CreateVendedorDto, Vendedor>();
            CreateMap<Vendedor, ReadVendedorDto>()
                 .ForMember(dto => dto.endereco, opt => opt.MapFrom(src => src.Endereco));
            CreateMap<UpdateVendedorDto, Vendedor>();

            CreateMap<Endereco, ReadEnderecoDto>();
        }
    }
}
