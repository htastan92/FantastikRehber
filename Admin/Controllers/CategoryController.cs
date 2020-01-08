using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.CategoryViewModels;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CategoryController(ICategoryService categoryService, IWebHostEnvironment hostingEnvironment)
        {
            _categoryService = categoryService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            CategoryListViewModel viewmodel = new CategoryListViewModel()
            {
                Categories = _categoryService.GetAllAdmin().Data
            };

            return View(viewmodel);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(CategoryNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (viewModel.Photos!=null&&viewModel.Photos.Count>0)
                {
                    foreach (IFormFile photo in viewModel.Photos)
                    {
                        var extension = Path.GetExtension(photo.FileName).ToLower();
                        if (extension==".jpg" || extension==".jpeg" ||extension==".png")
                        {
                            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                            uniqueFileName=Guid.NewGuid().ToString() +"_" + photo.FileName;
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            photo.CopyTo(new FileStream(filePath,FileMode.Create));
                        }
                        else
                        {
                            throw new Exception("Dosya türü .JPG , .JPEG veya .PNG olmalıdır");
                        }
                    }
                }
                var category = new Category()
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    StatusId = viewModel.StatusId,
                    Slug = viewModel.Slug,
                    ImageUrl = uniqueFileName,
                    CreatedBy = User.Identity.Name,
                    CreationDate = DateTime.Now
                };
                _categoryService.Add(category);
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

            var category = _categoryService.GetAdmin(id).Data;

            CategoryEditViewModel viewModel = new CategoryEditViewModel()
            {
                CategoryId = category.CategoryId,
                Title = category.Title,
                Slug = category.Slug,
                Description = category.Description,
                StatusId = category.StatusId,
                CreatedBy = User.Identity.Name,
                CreationDate = DateTime.Now.Date
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(CategoryEditViewModel viewModel)
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
                            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
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
                var category = new Category()
                {
                    CategoryId = viewModel.CategoryId,
                    Title = viewModel.Title,
                    Slug = viewModel.Slug,
                    ImageUrl = uniqueFileName,
                    StatusId = viewModel.StatusId,
                    Description = viewModel.Description,
                    CreatedBy = User.Identity.Name,
                    CreationDate = DateTime.Now.Date,
                };
                _categoryService.Update(category);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _categoryService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _categoryService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _categoryService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}