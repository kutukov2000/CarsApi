using BusinessLogic.ApiModels;
using DataAccess.Data.Entities;

namespace BusinessLogic.Interfaces
{
    public interface ICarsService
    {
        List<Car>? Get();
        Car? GetById(int id);
        void Create(CarDTO carDto);
        void Edit(EditCarModel car);
        void Delete(int id);
    }
}
