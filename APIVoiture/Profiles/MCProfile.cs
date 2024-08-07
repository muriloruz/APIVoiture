using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;

namespace APIVoiture.Profiles
{
    public class MCProfile : Profile
    {
        public MCProfile()
        {
            CreateMap<CreateMCDto, ModeloCarro>();
            CreateMap<ModeloCarro, ReadMCDto>();
        }
    }
}
