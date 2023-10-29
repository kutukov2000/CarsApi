using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BusinessLogic.Services
{
    public class CarsService : ICarsService
    {
        private readonly CarsApiDbContext _context;
        private readonly IMapper _mapper;
        public CarsService(CarsApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Create(CreateCarModel carDto)
        {
            Car car = _mapper.Map<Car>(carDto);

            //if (!ModelState.IsValid) return BadRequest();

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null) throw new HttpException("Invalid car ID.", HttpStatusCode.NotFound);

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(EditCarModel car)
        {
            Car existingCar = _mapper.Map<Car>(car);

            //if (!ModelState.IsValid) return BadRequest();

            _context.Cars.Update(existingCar);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CarDto>> Get()
        {
            List<Car> cars = await _context.Cars.Include(c => c.Category).ToListAsync();

            List<CarDto> carDtos = _mapper.Map<List<CarDto>>(cars);

            return carDtos;
        }

        public async Task<CarDto?> GetById(int id)
        {
            Car car = await _context.Cars.Include(c => c.Category).Where(c => c.Id == id).FirstOrDefaultAsync();

            if (car == null) throw new HttpException("Invalid car ID.", HttpStatusCode.NotFound);

            CarDto carDto = _mapper.Map<CarDto>(car);

            return carDto;
        }
    }
}
