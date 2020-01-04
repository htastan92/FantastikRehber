using System;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet("getlist")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAllWeb();
            return result.Success ? (IActionResult)Ok(result.Data) : BadRequest(result.Message);

        }

        // GET: api/Category/5
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _categoryService.GetAdmin(id);
            return result.Success ? (IActionResult)Ok(result.Data) : BadRequest(result.Message);
        }

        // POST: api/Category
        [HttpPost("add")]
        public IActionResult Add(Category category)
        {

            var result = _categoryService.Add(category);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);

        }

        // PUT: api/Category/5
        [HttpPost("update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("publish")]
        public IActionResult Publish(int id)
        {
            var result = _categoryService.Publish(id);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("{id}", Name = "publish")]
        public IActionResult Draft(int id)
        {
            var result = _categoryService.Draft(id);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("remove")]
        public IActionResult Remove(int id)
        {
            var result = _categoryService.Remove(id);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

    }
}
