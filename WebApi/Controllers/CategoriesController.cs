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
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAllAdmin();
            if (categories!=null)
            {
                return Ok(categories);
            }
            else
            {
                return NotFound();
            }
            
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var category = _categoryService.GetAdmin(id);
            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Category
        [HttpPost("add")]
        public void Add( Category category)
        {
            _categoryService.Add(category);
        }

        // PUT: api/Category/5
        [HttpPost("update")]
        public void Update(Category category)
        {
            _categoryService.Update(category);
        }

        [HttpPost("publish")]
        public bool Publish(int id)
        {
            return _categoryService.Publish(id);
        }

        [HttpPost("draft")]
        public bool Draft(int id)
        {
            return _categoryService.Draft(id);
        }
        [HttpPost("remove")]
        public bool Remove(int id)
        {
            return _categoryService.Remove(id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete")]
        public void Delete(Category category)
        {
            _categoryService.Delete(category);
        }

    }
}
