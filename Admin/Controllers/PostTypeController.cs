using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.PostTypeViewModels;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Authorize]
    public class PostTypeController : Controller
    {
        private readonly IPostTypeService _postTypeService;

        public PostTypeController(IPostTypeService postTypeService)
        {
            _postTypeService = postTypeService;
        }

        public IActionResult Index()
        {
            var viewModel = new PostTypeListViewModel()
            {
                PostTypes = _postTypeService.GetAll()
            };
            return View(viewModel);
        }

        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(PostTypeNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var postType = new PostType()
                {
                    Title = viewModel.Title
                };
                _postTypeService.Add(postType);
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        public IActionResult Edit(PostType postType)
        {
            if (postType == null)
                return RedirectToAction("Index");

            PostTypeEditViewModel viewModel = new PostTypeEditViewModel()
            {
                TypeId = postType.PostTypeId,
                Title = postType.Title
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(PostTypeEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var postType = new PostType()
                {
                    PostTypeId = viewModel.TypeId,
                    Title = viewModel.Title
                };
                _postTypeService.Update(postType);
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
           
        }

        public IActionResult Delete(PostType postType)
        {
            if (postType == null)
                return RedirectToAction("Index");

            _postTypeService.Delete(postType);
            return RedirectToAction("Index");
        }
    }
}