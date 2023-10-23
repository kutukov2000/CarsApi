using BusinessLogic.ApiModels;
using DataAccess.Data.Entities;

namespace BusinessLogic.Interfaces
{
    public interface ICategoriesService
    {
        List<Category>? Get();
        Category? GetById(int id);
        void Create(CreateCategoryModel createCategoryModel);
        void Edit(Category category);
        void Delete(int id);
    }
}
