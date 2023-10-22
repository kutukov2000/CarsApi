using AutoMapper;
using BusinessLogic.ApiModels;
using DataAccess.Data.Entities;

namespace BusinessLogic.Helpers
{
    public class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            CreateMap<CarDTO, Car>();
            CreateMap<EditCarModel, Car>();
        }
    }
}
