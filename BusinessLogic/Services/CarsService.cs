using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;

namespace BusinessLogic.Services
{
    public class CarsService : ICarsService
    {
        private readonly CarsApiDbContext _context;
        public CarsService(CarsApiDbContext context)
        {
            _context = context;
        }
        public void Create(CarDTO carDto)
        {
            var car = new Car
            {
                Producer = carDto.Producer,
                Model = carDto.Model,
                Year = carDto.Year,
                CategoryId = carDto.CategoryId
            };

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

        public void Edit(int id, CarDTO carDto)
        {
            var existingCar = _context.Cars.Find(id);
            if (existingCar == null) return;

            existingCar.Producer = carDto.Producer;
            existingCar.Model = carDto.Model;
            existingCar.Year = carDto.Year;
            existingCar.CategoryId = carDto.CategoryId;

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
