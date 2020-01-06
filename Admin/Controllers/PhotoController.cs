using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.PhotoViewModels;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Authorize]
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public IActionResult Index()
        {
            var viewmodel = new PhotoListViewModel()
            {
                Photos = _photoService.GetAllAdmin().Data
            };
            return View(viewmodel);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(PhotoNewViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                var photo = new Photo()
                {
                    Title = viewModel.Title,
                    Url = viewModel.Url,
                    CategoryId = viewModel.CategoryId,
                    StatusId = viewModel.StatusId,
                    CreatedBy = "Admin",
                    CreationDate = DateTime.Now.Date,
                    Description = viewModel.Description,
                    Slug = viewModel.Slug,
                    MemberId = viewModel.MemberId,
                    PostPhotos = null
                };
                _photoService.Add(photo);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(Photo photo)
        {
            if (photo == null)
                return RedirectToAction("Index");

            PhotoEditViewModel viewModel = new PhotoEditViewModel()
            {
                PhotoId = photo.PhotoId,
                Title = photo.Title,
                Description = photo.Description,
                Slug = photo.Slug,
                Url = photo.Url,
                CategoryId = photo.CategoryId,
                StatusId = photo.StatusId,
                CreatedBy = photo.CreatedBy,
                CreationDate = DateTime.Now.Date,
                MemberId = photo.MemberId,
                PostPhotos = null
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(PhotoEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                Photo photo = new Photo()
                {
                    PhotoId = viewModel.PhotoId,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Slug = viewModel.Slug,
                    Url = viewModel.Url,
                    CategoryId = viewModel.CategoryId,
                    StatusId = viewModel.StatusId,
                    CreatedBy = viewModel.CreatedBy,
                    CreationDate = viewModel.CreationDate,
                    MemberId = viewModel.MemberId,
                    PostPhotos = null
                };
                _photoService.Update(photo);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Publish(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            _photoService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            _photoService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            _photoService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}