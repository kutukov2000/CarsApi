using CarsApi.Helpers;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly CarsApiDbContext _context;

        public CarsController(CarsApiDbContext context)
        {
            _context = context;
        }
        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(_context.Cars.ToList()); // status: 200
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Car car = _context.Cars.Find(id);

            if (car == null) return NotFound(); // 404

            return Ok(car);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CarDTO carDto)
        {
            var car = new Car
            {
                Producer = carDto.Producer,
                Model = carDto.Model,
                Year = carDto.Year,
                CategoryId = carDto.CategoryId
            };

            if (!ModelState.IsValid) return BadRequest();

            _context.Cars.Add(car);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(int id, [FromBody] CarDTO carDto)
        {
            var existingCar = _context.Cars.Find(id);
            if (existingCar == null) return NotFound();

            existingCar.Producer = carDto.Producer;
            existingCar.Model = carDto.Model;
            existingCar.Year = carDto.Year;
            existingCar.CategoryId = carDto.CategoryId;

            if (!ModelState.IsValid) return BadRequest();

            _context.Cars.Update(existingCar);
            _context.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = _context.Cars.Find(id);

            if (item == null) return NotFound();

            _context.Cars.Remove(item);
            _context.SaveChanges();

            return Ok();
        }
    }
}
