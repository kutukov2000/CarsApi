using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Exceptions;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using FluentValidation;
using System.Net;

namespace BusinessLogic.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> _categoriesRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Category> _editCategoryModelValidator;
        private readonly IValidator<CreateCategoryModel> _createCategoryModelValidator;
        public CategoriesService(IRepository<Category> categoriesRepository, IMapper mapper, IValidator<Category> validator, IValidator<CreateCategoryModel> createCategoryModelValidator)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
            _editCategoryModelValidator = validator;
            _createCategoryModelValidator = createCategoryModelValidator;
        }
        public async Task Create(CreateCategoryModel createCategoryModel)
        {
            ValidationHelper<CreateCategoryModel>.Validate(_createCategoryModelValidator, createCategoryModel);

            Category category = _mapper.Map<Category>(createCategoryModel);

            await _categoriesRepository.InsertAsync(category);
            await _categoriesRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _categoriesRepository.GetByIdAsync(id);

            if (item == null) throw new HttpException("Invalid category ID.", HttpStatusCode.NotFound);

            _categoriesRepository.Delete(item);
            await _categoriesRepository.SaveAsync();
        }

        public async Task Edit(Category category)
        {
            ValidationHelper<Category>.Validate(_editCategoryModelValidator, category);

            Category existingCategory = _mapper.Map<Category>(category);

            _categoriesRepository.Update(existingCategory);
            await _categoriesRepository.SaveAsync();
        }

        public async Task<List<Category>?> Get()
        {
            List<Category> categories = await _categoriesRepository.GetAllAsync();

            return categories;
        }

        public async Task<Category?> GetById(int id)
        {
            Category category = await _categoriesRepository.GetByIdAsync(id);

            if (category == null) throw new HttpException("Invalid category ID.", HttpStatusCode.NotFound);

            return category;
        }
    }
}
