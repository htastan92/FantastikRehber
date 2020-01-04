using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Admin.Models;
using Admin.Models.PostViewModels;
using Business.Abstract;
using Entities;

namespace Admin.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
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
            var post = new Post()
            {
                Title = viewModel.Title,
                StatusId = viewModel.Status.StatusId,
                CategoryId = viewModel.Category.CategoryId,
                CreationDate = DateTime.Now,
                Description = viewModel.Description,
                CreatedBy = "Hüseyin Taştan",
                Slug = viewModel.Slug
            };
            _postService.Add(post);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Post post)
        {
            var viewmodel = new PostEditViewModel()
            {
                PostId = post.PostId,
                Title = post.Title,
                Description = post.Description,
                Slug = post.Slug,
                CategoryId = post.CategoryId,
                StatusId = post.StatusId,
                CreatedBy = post.CreatedBy,
                CreationDate = post.CreationDate
            };
            return View("Edit");
        }
        [HttpPost]
        public IActionResult Edit(PostEditViewModel viewModel)
        {
            var post = new Post()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                Slug = viewModel.Slug,
                CategoryId = viewModel.CategoryId,
                CreatedBy = viewModel.CreatedBy,
                CreationDate = viewModel.CreationDate,
                StatusId = viewModel.Status.StatusId,
                PostId = viewModel.PostId
            };
            _postService.Update(post);
            return RedirectToAction("Index");
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
