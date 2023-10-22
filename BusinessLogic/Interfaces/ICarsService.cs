using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;

namespace BusinessLogic.Interfaces
{
    public interface ICarsService
    {
        List<CarDto>? Get();
        CarDto? GetById(int id);
        void Create(CreateCarModel carDto);
        void Edit(EditCarModel car);
        void Delete(int id);
    }
}
