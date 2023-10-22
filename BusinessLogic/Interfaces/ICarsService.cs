using BusinessLogic.Helpers;
using DataAccess.Data.Entities;

namespace BusinessLogic.Interfaces
{
    public interface ICarsService
    {
        List<Car>? Get();
        Car? GetById(int id);
        void Create(CarDTO carDto);
        void Edit(int id, CarDTO carDto);
        void Delete(int id);
    }
}
