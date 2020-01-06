using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.CommentViewModels;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var viewmodel = new CommentListViewModel()
            {
                Comments = _commentService.GetAllAdmin().Data
            };
            return View(viewmodel);
        }

        public IActionResult Publish(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            _commentService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            _commentService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            _commentService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}