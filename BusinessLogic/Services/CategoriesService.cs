using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BusinessLogic.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly CarsApiDbContext _context;
        private readonly IMapper _mapper;
        public CategoriesService(CarsApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Create(CreateCategoryModel createCategoryModel)
        {
            Category category = _mapper.Map<Category>(createCategoryModel);

            //if (!ModelState.IsValid) return BadRequest();

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _context.Categories.FindAsync(id);

            if (item == null) throw new HttpException("Invalid category ID.", HttpStatusCode.NotFound);

            _context.Categories.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Category category)
        {
            Category existingCategory = _mapper.Map<Category>(category);

            //if (!ModelState.IsValid) return BadRequest();

            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>?> Get()
        {
            List<Category> categories = await _context.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category?> GetById(int id)
        {
            Category category = await _context.Categories.FindAsync(id);

            if (category == null) throw new HttpException("Invalid category ID.", HttpStatusCode.NotFound);

            return category;
        }
    }
}
