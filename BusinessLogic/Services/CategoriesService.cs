using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;

namespace BusinessLogic.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly CarsApiDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<Category> _validator;
        private readonly IValidator<CreateCategoryModel> _createCategoryModelValidator;
        public CategoriesService(CarsApiDbContext context, IMapper mapper, IValidator<Category> validator, IValidator<CreateCategoryModel> createCategoryModelValidator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _createCategoryModelValidator = createCategoryModelValidator;
        }
        public async Task Create(CreateCategoryModel createCategoryModel)
        {
            ValidationResult results = _createCategoryModelValidator.Validate(createCategoryModel);

            if (!results.IsValid)
            {
                ThrowBadRequestExeption(results);
            }

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
            Category existingCategory = _mapper.Map<Category>(category);

            ValidationResult results = _validator.Validate(existingCategory);

            if (!results.IsValid)
            {
                ThrowBadRequestExeption(results);
            }

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

        private void ThrowBadRequestExeption(ValidationResult results)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var failure in results.Errors)
            {
                stringBuilder.Append($"{failure.ErrorMessage} ");
            }

            throw new HttpException(stringBuilder.ToString(), HttpStatusCode.BadRequest);
        }
    }
}
