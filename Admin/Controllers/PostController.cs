using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Admin.Models;
using Admin.Models.PostViewModels;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Admin.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PostController(IPostService postService, IWebHostEnvironment hostEnvironment)
        {
            _postService = postService;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            PostListViewModel viewModel = new PostListViewModel()
            {
                Posts = _postService.GetAllAdmin().Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(PostNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (viewModel.Photos != null && viewModel.Photos.Count > 0)
                {
                    foreach (IFormFile photo in viewModel.Photos)
                    {
                        var extension = Path.GetExtension(photo.FileName).ToLower();
                        if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                        {
                            string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                            uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            photo.CopyTo(new FileStream(filePath, FileMode.Create));
                        }
                        else
                        {
                            throw new Exception("Dosya türü .JPG , .JPEG veya .PNG olmalıdır");
                        }
                    }
                }
                var post = new Post()
                {
                    Title = viewModel.Title,
                    StatusId = viewModel.StatusId,
                    CategoryId = viewModel.CategoryId,
                    ImageUrl = uniqueFileName,
                    CreationDate = DateTime.Now,
                    Description = viewModel.Description,
                    CreatedBy = User.Identity.Name,
                    Slug = viewModel.Slug,
                    TypeId = viewModel.PostTypeId,
                    EditorContent = viewModel.EditorContent,
                };
                _postService.Add(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }


        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var post = _postService.GetAdmin(id).Data;

            var viewmodel = new PostEditViewModel()
            {
                PostId = post.PostId,
                Title = post.Title,
                Description = post.Description,
                Slug = post.Slug,
                CategoryId = post.CategoryId,
                StatusId = post.StatusId,
                CreatedBy = post.CreatedBy,
                CreationDate = post.CreationDate,
                PostTypeId = post.TypeId,
                EditorContent = post.EditorContent,
                ImageUrl = post.ImageUrl,
                
            };
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult Edit(PostEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                string uniqueFileName = null;
                if (viewModel.Photos != null && viewModel.Photos.Count > 0)
                {
                    foreach (IFormFile photo in viewModel.Photos)
                    {
                        var extension = Path.GetExtension(photo.FileName).ToLower();
                        if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                        {
                            string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                            uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            photo.CopyTo(new FileStream(filePath, FileMode.Create));
                        }
                        else
                        {
                            throw new Exception("Dosya türü .JPG , .JPEG veya .PNG olmalıdır");
                        }
                    }
                }
                var post = new Post()
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Slug = viewModel.Slug,
                    ImageUrl = uniqueFileName,
                    CategoryId = viewModel.CategoryId,
                    CreatedBy = User.Identity.Name,
                    CreationDate = DateTime.Now,
                    StatusId = viewModel.StatusId,
                    PostId = viewModel.PostId,
                    TypeId = viewModel.PostTypeId,
                    EditorContent = viewModel.EditorContent
                };
                _postService.Update(post);
                return RedirectToAction("Index");
            }

        }

        public IActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _postService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _postService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _postService.Remove(id);
            return RedirectToAction("Index");
        }


    }
}
