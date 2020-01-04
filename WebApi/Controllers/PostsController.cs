using System;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/Category
        [HttpGet("getlist")]
        public IActionResult GetAll()
        {
            var result = _postService.GetAllWeb();
            return result.Success ? (IActionResult)Ok(result.Data) : BadRequest(result.Message);

        }

        // GET: api/Category/5
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _postService.GetAdmin(id);
            return result.Success ? (IActionResult)Ok(result.Data) : BadRequest(result.Message);
        }

        // POST: api/Category
        [HttpPost("add")]
        public IActionResult Add(Post post)
        {

            var result = _postService.Add(post);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);

        }

        // PUT: api/Category/5
        [HttpPost("update")]
        public IActionResult Update(Post post)
        {
            var result = _postService.Update(post);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("publish")]
        public IActionResult Publish(int id)
        {
            var result = _postService.Publish(id);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("draft")]
        public IActionResult Draft(int id)
        {
            var result = _postService.Draft(id);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("remove")]
        public IActionResult Remove(int id)
        {
            var result = _postService.Remove(id);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

    }
}
