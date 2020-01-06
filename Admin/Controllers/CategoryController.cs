using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.CategoryViewModels;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
                var category = new Category()
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    StatusId = viewModel.StatusId,
                    Slug = viewModel.Slug,
                    CreatedBy = "Hüseyin Taştan",
                    CreationDate = DateTime.Now.Date,
                };
                _categoryService.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        public IActionResult Edit(Category category)
        {
            if (category == null)
                return RedirectToAction("Index");

            CategoryEditViewModel viewModel = new CategoryEditViewModel()
            {
                CategoryId = category.CategoryId,
                Title = category.Title,
                Slug = category.Slug,
                Description = category.Description,
                StatusId = category.StatusId,
                CreatedBy = "Admin",
                CreationDate = DateTime.Now.Date,
                Posts = null,
                Photos = null
            };
            return View(viewModel);
        }

        public IActionResult Edit(CategoryEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                var category = new Category()
                {
                    CategoryId = viewModel.CategoryId,
                    Title = viewModel.Title,
                    Slug = viewModel.Slug,
                    StatusId = 2,
                    Description = viewModel.Description,
                    CreatedBy = "Admin",
                    CreationDate = DateTime.Now.Date,
                    Posts = null,
                    Photos = null
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