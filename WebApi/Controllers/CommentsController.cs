using System;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/Category
        [HttpGet("getlist")]
        public IActionResult GetAll()
        {
            var result = _commentService.GetAllWeb();
            return result.Success ? (IActionResult)Ok(result.Data) : BadRequest(result.Message);

        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var result = _commentService.GetAdmin(id);
            return result.Success ? (IActionResult)Ok(result.Data) : BadRequest(result.Message);
        }

        // POST: api/Category
        [HttpPost("add")]
        public IActionResult Add(Comment comment)
        {

            var result = _commentService.Add(comment);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);

        }

        // PUT: api/Category/5
        [HttpPost("update")]
        public IActionResult Update(Comment comment)
        {
            var result = _commentService.Update(comment);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("publish")]
        public IActionResult Publish(int id)
        {
            var result = _commentService.Publish(id);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("{id}", Name = "publish")]
        public IActionResult Draft(int id)
        {
            var result = _commentService.Draft(id);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("remove")]
        public IActionResult Remove(int id)
        {
            var result = _commentService.Remove(id);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

    }
}
