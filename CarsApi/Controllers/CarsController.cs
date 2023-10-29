using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarsService _service;

        public CarsController(ICarsService service)
        {
            _service = service;
        }
        [HttpGet("all")]
        public IActionResult Get()
        {
            List<CarDto> cars = _service.Get().Result;

            return Ok(cars);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            CarDto car = _service.GetById(id).Result!;

            return Ok(car);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCarModel carDto)
        {
            _service.Create(carDto);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditCarModel carDto)
        {
            _service.Edit(carDto);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);

            return Ok();
        }
    }
}
