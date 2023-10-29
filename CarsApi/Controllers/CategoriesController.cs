using BusinessLogic.ApiModels;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _service;

        public CategoriesController(ICategoriesService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            List<Category> categories = await _service.Get();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Category category = await _service.GetById(id);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryModel category)
        {
            await _service.Create(category);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Category category)
        {
            await _service.Edit(category);

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return Ok();
        }
    }
}
