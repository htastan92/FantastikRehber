using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.ProductionTypeViewModels;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Authorize]
    public class PostTypeController : Controller
    {
        private readonly IProductionTypeService _productionTypeService;

        public PostTypeController(IProductionTypeService productionTypeService)
        {
            _productionTypeService = productionTypeService;
        }

        public IActionResult Index()
        {
            var viewModel = new ProductionTypeListViewModel()
            {
                PostTypes = _productionTypeService.GetAll()
            };
            return View(viewModel);
        }

        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(ProductionTypeNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var productionType = new ProductionType()
                {
                    Title = viewModel.Title
                };
                _productionTypeService.Add(productionType);
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        public IActionResult Edit(ProductionType productionType)
        {
            if (productionType == null)
                return RedirectToAction("Index");

            ProductionTypeEditViewModel viewModel = new ProductionTypeEditViewModel()
            {
                TypeId = productionType.ProductionTypeId,
                Title = productionType.Title
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductionTypeEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var productionType = new ProductionType()
                {
                    ProductionTypeId = viewModel.TypeId,
                    Title = viewModel.Title
                };
                _productionTypeService.Update(productionType);
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
           
        }

        public IActionResult Delete(ProductionType productionType)
        {
            if (productionType == null)
                return RedirectToAction("Index");

            _productionTypeService.Delete(productionType);
            return RedirectToAction("Index");
        }
    }
}