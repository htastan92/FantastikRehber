using System;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        // GET: api/Category
        [HttpGet("getlist")]
        public IActionResult GetAll()
        {
            var result = _photoService.GetAllWeb();
            return result.Success ? (IActionResult)Ok(result.Data) : BadRequest(result.Message);

        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var result = _photoService.GetAdmin(id);
            return result.Success ? (IActionResult)Ok(result.Data) : BadRequest(result.Message);
        }

        // POST: api/Category
        [HttpPost("add")]
        public IActionResult Add(Photo photo)
        {

            var result = _photoService.Add(photo);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);

        }

        // PUT: api/Category/5
        [HttpPost("update")]
        public IActionResult Update(Photo photo)
        {
            var result = _photoService.Update(photo);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("publish")]
        public IActionResult Publish(int id)
        {
            var result = _photoService.Publish(id);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("{id}", Name = "publish")]
        public IActionResult Draft(int id)
        {
            var result = _photoService.Draft(id);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("remove")]
        public IActionResult Remove(int id)
        {
            var result = _photoService.Remove(id);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

    }
}
