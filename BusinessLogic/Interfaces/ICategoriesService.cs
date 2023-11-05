using Core.ApiModels;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<Category>?> Get();
        Task<Category?> GetById(int id);
        Task Create(CreateCategoryModel createCategoryModel);
        Task Edit(Category category);
        Task Delete(int id);
    }
}
