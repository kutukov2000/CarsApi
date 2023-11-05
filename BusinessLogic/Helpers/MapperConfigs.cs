using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using BusinessLogic.Entities;

namespace BusinessLogic.Helpers
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
