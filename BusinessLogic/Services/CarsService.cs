using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;

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
        public void Create(CarDTO carDto)
        {
            Car car = _mapper.Map<Car>(carDto);

            //if (!ModelState.IsValid) return BadRequest();

            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Cars.Find(id);

            if (item == null) return;

            _context.Cars.Remove(item);
            _context.SaveChanges();
        }

        public void Edit(EditCarModel car)
        {
            Car existingCar = _mapper.Map<Car>(car);

            //if (!ModelState.IsValid) return BadRequest();

            _context.Cars.Update(existingCar);
            _context.SaveChanges();
        }

        public List<Car> Get()
        {
            return _context.Cars.ToList();
        }

        public Car? GetById(int id)
        {
            Car car = _context.Cars.Find(id);

            if (car == null) return null;

            return car;
        }
    }
}
