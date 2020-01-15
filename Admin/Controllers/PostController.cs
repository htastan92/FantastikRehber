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
using Business.Helper;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IPostCategoryService _postCategoryService;
        private readonly ICategoryService _categoryService;
    

        public PostController(IPostService postService, IWebHostEnvironment hostEnvironment, IPostCategoryService postCategoryService, ICategoryService categoryService)
        {
            _postService = postService;
            _hostEnvironment = hostEnvironment;
            _postCategoryService = postCategoryService;
            _categoryService = categoryService;
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
            var viewModel = new PostNewViewModel()
            {
                Categories = _categoryService.GetAllAdmin().Data
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult New(PostNewViewModel viewModel, string[] categories)
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
                    ImageUrl = uniqueFileName,
                    CreationDate = DateTime.Now,
                    Description = viewModel.Description,
                    CreatedBy = User.Identity.Name,
                    UpdatedBy = User.Identity.Name,
                    UpdatedAt = DateTime.Now.Date,
                    Slug = viewModel.Slug,
                    TypeId = viewModel.ProductionTypeId,
                    EditorContent = viewModel.EditorContent,
                };
                _postService.Add(post);

                foreach (var categoryId in categories)
                {
                    var postCategory = new PostCategory()
                    {
                        CategoryId = Convert.ToInt32(categoryId),
                        PostId = post.PostId
                    };
                    _postCategoryService.Add(postCategory);
                }
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
            var selectedCategories = _categoryService.GetAllByPostId(post.PostId).Data;
            var categories = _categoryService.GetAllAdmin().Data;
            var viewmodel = new PostEditViewModel()
            {
                PostId = post.PostId,
                Title = post.Title,
                Description = post.Description,
                Slug = post.Slug,
                StatusId = post.StatusId,
                Categories = categories,
                SelectedCategories = selectedCategories,
                CreatedBy = post.CreatedBy,
                CreationDate = post.CreationDate,
                ProductionTypeId = post.TypeId,
                EditorContent = post.EditorContent,
                ImageUrl = post.ImageUrl,
                
            };
            
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult Edit(PostEditViewModel viewModel,string[] categories)
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
                    CreatedBy = viewModel.CreatedBy,
                    CreationDate = viewModel.CreationDate,
                    UpdatedBy = User.Identity.Name,
                    UpdatedAt = DateTime.Now.Date,
                    StatusId = viewModel.StatusId,
                    PostId = viewModel.PostId,
                    TypeId = viewModel.ProductionTypeId,
                    EditorContent = viewModel.EditorContent
                };

                _postService.Update(post);
                var oldCategories = _postCategoryService.GetAllByPostId(post.PostId);
                foreach (var category in oldCategories)
                {
                    _postCategoryService.Delete(category);
                }
                foreach (var categoryId in categories)
                {
                    var postCategory = new PostCategory()
                    {
                        PostId = viewModel.PostId,
                        CategoryId = Convert.ToInt32(categoryId)
                    };
                    _postCategoryService.Add(postCategory);
                }
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
