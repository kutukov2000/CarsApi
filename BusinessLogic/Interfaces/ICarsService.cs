using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;

namespace BusinessLogic.Interfaces
{
    public interface ICarsService
    {
        Task<List<CarDto>>? Get();
        Task<EditCarModel?> GetById(int id);
        Task Create(CreateCarModel carDto);
        Task Edit(EditCarModel car);
        Task Delete(int id);
    }
}
