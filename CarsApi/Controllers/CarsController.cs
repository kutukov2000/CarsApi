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
        public async Task<IActionResult> Get()
        {
            List<CarDto> cars = await _service.Get();

            return Ok(cars);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            CarDto car = await _service.GetById(id);

            return Ok(car);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCarModel carDto)
        {
            await _service.Create(carDto);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditCarModel carDto)
        {
            await _service.Edit(carDto);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return Ok();
        }
    }
}
