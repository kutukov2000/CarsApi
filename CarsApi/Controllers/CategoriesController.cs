using BusinessLogic.ApiModels;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
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
        public IActionResult Get()
        {
            List<Category> categories = _service.Get().Result;

            return Ok(categories); // status: 200
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Category category = _service.GetById(id).Result;

            return Ok(category);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryModel category)
        {
            _service.Create(category);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Category category)
        {
            _service.Edit(category);

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
