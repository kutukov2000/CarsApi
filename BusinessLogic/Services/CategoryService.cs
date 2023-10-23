using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoriesService
    {
        private readonly CarsApiDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(CarsApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Create(CreateCategoryModel createCategoryModel)
        {
            DataAccess.Data.Entities.Category category = _mapper.Map<DataAccess.Data.Entities.Category>(createCategoryModel);

            //if (!ModelState.IsValid) return BadRequest();

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Categories.Find(id);

            if (item == null) return;

            _context.Categories.Remove(item);
            _context.SaveChanges();
        }

        public void Edit(Category category)
        {
            Category existingCategory = _mapper.Map<Category>(category);

            //if (!ModelState.IsValid) return BadRequest();

            _context.Categories.Update(existingCategory);
            _context.SaveChanges();
        }

        public List<Category> Get()
        {
            List<Category> categories = _context.Categories.ToList();

            return categories;
        }

        public Category? GetById(int id)
        {
            Category category = _context.Categories.Find(id);

            if (category == null) return null;

            return category;
        }
    }
}
