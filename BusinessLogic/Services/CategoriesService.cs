using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Exceptions;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BusinessLogic.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly CarsApiDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<Category> _editCategoryModelValidator;
        private readonly IValidator<CreateCategoryModel> _createCategoryModelValidator;
        public CategoriesService(CarsApiDbContext context, IMapper mapper, IValidator<Category> validator, IValidator<CreateCategoryModel> createCategoryModelValidator)
        {
            _context = context;
            _mapper = mapper;
            _editCategoryModelValidator = validator;
            _createCategoryModelValidator = createCategoryModelValidator;
        }
        public async Task Create(CreateCategoryModel createCategoryModel)
        {
            ValidationHelper<CreateCategoryModel>.Validate(_createCategoryModelValidator, createCategoryModel);

            Category category = _mapper.Map<Category>(createCategoryModel);

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
            ValidationHelper<Category>.Validate(_editCategoryModelValidator, category);

            Category existingCategory = _mapper.Map<Category>(category);

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
