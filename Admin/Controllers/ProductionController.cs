using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.ProductionViewModels;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IProductionService _productionService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IProductionCategoryService _productionCategoryService;
        private readonly IProductionPerformerService _productionPerformerService;
        private readonly ICategoryService _categoryService;
        private readonly IPerformerService _performerService;


        public ProductionController(IProductionService productionService, IWebHostEnvironment hostEnvironment, IProductionCategoryService productionCategoryService, IProductionPerformerService productionPerformerService, ICategoryService categoryService, IPerformerService performerService)
        {
            _productionService = productionService;
            _hostEnvironment = hostEnvironment;
            _productionCategoryService = productionCategoryService;
            _productionPerformerService = productionPerformerService;
            _categoryService = categoryService;
            _performerService = performerService;
        }

        public IActionResult Index()
        {
            var viewModel = new ProductionListViewModel()
            {
                Productions = _productionService.GetAllAdmin().Data
            };
            return View(viewModel);
        }

        public IActionResult New()
        {
            var viewModel =  new ProductionNewViewModel()
            {
                Categories = _categoryService.GetAllAdmin().Data,
                Performers = _performerService.GetAll().Data
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult New(ProductionNewViewModel viewModel,string[] categories , string[] performers)
        {
            var x = performers;
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
                            string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images/ProductionImages");
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
                var production = new Production()
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    StatusId = viewModel.StatusId,
                    Slug = viewModel.Slug,
                    ImageUrl = uniqueFileName ,
                    ProductionTypeId = viewModel.ProductionTypeId,
                    ImdbScore = viewModel.ImdbScore,
                    MetaCriticScore = viewModel.MetaCriticScore,
                    ReleaseDate = viewModel.ReleaseDate,
                    CreatedBy = User.Identity.Name,
                    CreationDate = DateTime.Now.Date,
                    UpdatedBy = User.Identity.Name,
                    UpdatedAt = DateTime.Now.Date
                };

                _productionService.Add(production);
                foreach (var categoryId in categories)
                {
                    var productionCategory = new ProductionCategory()
                    {
                        CategoryId = Convert.ToInt32(categoryId),
                        ProductionId = production.ProductionId
                    };
                    _productionCategoryService.Add(productionCategory);
                }

                foreach (var performerId in performers)
                {
                    var productionPerformer = new ProductionPerformer()
                    {
                        ProductionId = production.ProductionId,
                        PerformerId = Convert.ToInt32(performerId)
                    };
                    _productionPerformerService.Add(productionPerformer);
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

            var production = _productionService.GetAdmin(id).Data;

            var categories = _categoryService.GetAllAdmin().Data;
            var selectedCategories = _categoryService.GetAllByProductionId(production.ProductionId).Data;

            var performers = _performerService.GetAll().Data;
            var selectedPerformers = _performerService.GetAllByProductionId(production.ProductionId).Data;

      
            var viewmodel = new ProductionEditViewModel()
            {
                Title = production.Title,
                Description = production.Description,
                Slug = production.Slug,
                ImageUrl = production.ImageUrl,
                StatusId = production.StatusId,
                ProductionTypeId = production.ProductionTypeId,
                ProductionId = production.ProductionId,
                MetaCriticScore = production.MetaCriticScore,
                ReleaseDate = production.ReleaseDate,
                ImdbScore = production.ImdbScore,
                CreatedBy = production.CreatedBy,
                CreationDate = production.CreationDate,
                UpdatedBy = production.UpdatedBy,
                UpdatedAt = production.UpdatedAt,
                Categories = categories,
                SelectedCategories = selectedCategories,
                Performers = performers,
                SelectedPerformers = selectedPerformers
            };
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Edit(ProductionEditViewModel viewModel,string[] categories , string[] performers)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
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
                            string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images/ProductionImages");
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
                var production = new Production()
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Slug = viewModel.Slug,
                    ImageUrl = uniqueFileName,
                    StatusId = viewModel.StatusId,
                    ImdbScore = viewModel.ImdbScore,
                    MetaCriticScore = viewModel.MetaCriticScore,
                    ProductionId = viewModel.ProductionId,
                    ProductionTypeId = viewModel.ProductionTypeId,
                    ReleaseDate = viewModel.ReleaseDate,
                    CreatedBy = viewModel.CreatedBy,
                    CreationDate = viewModel.CreationDate,
                    UpdatedBy = User.Identity.Name,
                    UpdatedAt = DateTime.Now.Date
                };
                _productionService.Update(production);
                var oldCategories = _productionCategoryService.GetAllByProductionId(production.ProductionId);
                foreach (var oldCategory in  oldCategories )
                {
                    _productionCategoryService.Delete(oldCategory);
                }
                foreach (var categoryId in categories)
                {
                    var productionCategory = new ProductionCategory()
                    {
                        CategoryId = Convert.ToInt32(categoryId),
                        ProductionId = production.ProductionId
                    };
                    _productionCategoryService.Add(productionCategory);
                }

                var oldPerformers = _productionPerformerService.GetAllPerformersByProduction(production.ProductionId);
                foreach (var oldPerformer in oldPerformers)
                {
                    _productionPerformerService.Delete(oldPerformer);
                }
                foreach (var performerId in performers)
                {
                    var productionPerformer = new ProductionPerformer()
                    {
                        PerformerId = Convert.ToInt32(performerId),
                        ProductionId = production.ProductionId
                    };
                    _productionPerformerService.Add(productionPerformer);
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _productionService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _productionService.Draft(id);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _productionService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}