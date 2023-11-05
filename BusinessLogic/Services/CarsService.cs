using AutoMapper;
using Core.ApiModels;
using Core.Dtos;
using Core.Entities;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using FluentValidation;
using System.Net;

namespace Core.Services
{
    public class CarsService : ICarsService
    {
        private readonly IRepository<Car> _carsRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCarModel> _createCarModelValidator;
        private readonly IValidator<EditCarModel> _editCarModelValidator;
        public CarsService(IRepository<Car> carsRepository, IMapper mapper, IValidator<CreateCarModel> createCarModelValidator, IValidator<EditCarModel> editCarModelValidator)
        {
            _carsRepository = carsRepository;
            _mapper = mapper;
            _createCarModelValidator = createCarModelValidator;
            _editCarModelValidator = editCarModelValidator;
        }
        public async Task Create(CreateCarModel carDto)
        {
            ValidationHelper<CreateCarModel>.Validate(_createCarModelValidator, carDto);

            Car car = _mapper.Map<Car>(carDto);

            await _carsRepository.InsertAsync(car);
            await _carsRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var car = await _carsRepository.GetByIdAsync(id);

            if (car == null) throw new HttpException("Invalid car ID.", HttpStatusCode.NotFound);

            _carsRepository.Delete(car);
            await _carsRepository.SaveAsync();
        }

        public async Task Edit(EditCarModel car)
        {
            ValidationHelper<EditCarModel>.Validate(_editCarModelValidator, car);

            Car existingCar = _mapper.Map<Car>(car);

            _carsRepository.Update(existingCar);
            await _carsRepository.SaveAsync();
        }

        public async Task<List<CarDto>> Get()
        {
            List<Car> cars = await _carsRepository.GetAllAsync(includeProperties: "Category");

            List<CarDto> carDtos = _mapper.Map<List<CarDto>>(cars);

            return carDtos;
        }

        public async Task<EditCarModel?> GetById(int id)
        {
            Car car = await _carsRepository.GetByIdAsync(id);

            if (car == null) throw new HttpException("Invalid car ID.", HttpStatusCode.NotFound);

            EditCarModel carDto = _mapper.Map<EditCarModel>(car);

            return carDto;
        }
    }
}
