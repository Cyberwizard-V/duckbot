using AutoMapper;
using DuckAPI.Dto;
using DuckAPI.Models;

namespace DuckAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Duck, DuckDto>();

        }
    }
}
