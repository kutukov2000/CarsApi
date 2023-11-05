using AutoMapper;
using Core.ApiModels;
using Core.Dtos;
using Core.Entities;

namespace Core.Helpers
{
    public class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            //Maps for Car model
            CreateMap<CreateCarModel, Car>().ReverseMap();
            CreateMap<EditCarModel, Car>().ReverseMap();

            CreateMap<CarDto, Car>().ReverseMap();

            //Maps for Category model
            CreateMap<CreateCategoryModel, Category>().ReverseMap();
        }
    }
}
