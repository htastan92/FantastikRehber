using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.PerformerViewModels;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class PerformerController : Controller
    {
        private readonly IPerformerService _performerService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IProductionPerformerService _productionPerformerService;

        public PerformerController(IPerformerService performerService, IWebHostEnvironment hostEnvironment, IProductionPerformerService productionPerformerService)
        {
            _performerService = performerService;
            _hostEnvironment = hostEnvironment;
            _productionPerformerService = productionPerformerService;
        }

        public IActionResult Index()
        {
            var viewModel = new PerformerListViewModel()
            {
                Performers = _performerService.GetAll().Data
            };
            return View(viewModel);
        }

        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(PerformerNewViewModel viewModel)
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
                                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images/PerformerImages");
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
                    var performer = new Performer()
                    {
                        Slug = viewModel.Slug,
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        ImageUrl = uniqueFileName,
                        Birthdate = viewModel.Birthdate,
                        Information = viewModel.Information,
                        CreatedBy = User.Identity.Name,
                        CreationDate = DateTime.Now.Date,
                        UpdatedBy = User.Identity.Name,
                        UpdatedAt = DateTime.Now.Date
                    };

                    _performerService.Add(performer);
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

            var performer = _performerService.Get(id).Data;
            var viewModel = new PerformerEditViewModel()
            {
                Slug = performer.Slug,
                PerformerId = performer.PerformerId,
                ImageUrl = performer.ImageUrl,
                FirstName = performer.FirstName,
                LastName = performer.LastName,
                Birthdate = performer.Birthdate,
                Information = performer.Information,
                CreatedBy = performer.CreatedBy,
                CreationDate = performer.CreationDate,
                UpdatedAt = performer.UpdatedAt,
                UpdatedBy = performer.UpdatedBy
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(PerformerEditViewModel viewModel)
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
                            string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images/PerformerImages");
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
                var performer = new Performer()
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Slug = viewModel.Slug,
                    ImageUrl = uniqueFileName,
                    PerformerId = viewModel.PerformerId,
                    Birthdate = viewModel.Birthdate,
                    Information = viewModel.Information,
                    CreatedBy = viewModel.CreatedBy,
                    CreationDate = viewModel.CreationDate,
                    UpdatedBy = User.Identity.Name,
                    UpdatedAt = DateTime.Now.Date
                };
                _performerService.Update(performer);
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var performer = _performerService.Get(id).Data;
            var productionPerformers = _productionPerformerService.GetAllProductionsByPerformer(id);
            foreach (var productionPerformer in productionPerformers)
            {
                _productionPerformerService.Delete(productionPerformer);
            }
            _performerService.Delete(performer);
            return RedirectToAction("Index");
        }
    }
}