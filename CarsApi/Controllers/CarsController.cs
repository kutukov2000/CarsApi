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
        public IActionResult Create(Car car)
        {
            if (!ModelState.IsValid) return BadRequest();

            _context.Cars.Add(car);
            _context.SaveChanges();

            return Ok();
        }
        [HttpPut]
        public IActionResult Edit(Car car)
        {
            if (!ModelState.IsValid) return BadRequest();

            _context.Cars.Update(car);
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
