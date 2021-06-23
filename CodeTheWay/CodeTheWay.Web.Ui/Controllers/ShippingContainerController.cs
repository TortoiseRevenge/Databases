using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models.ViewModels;

namespace CodeTheWay.Web.Ui.Controllers
{
    public class ShippingContainerController : Controller
    {
        private IShippingContainerService ShippingContainerService;
        public ShippingContainerController(IShippingContainerService shippingContainerService)
        {
            this.ShippingContainerService = shippingContainerService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await ShippingContainerService.GetContainers());
        }
        public async Task<IActionResult> Create()
        {
            return View(new ShippingContainerRegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(ShippingContainerRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Weight <= 10000)
                {
                    ShippingContainer container = new ShippingContainer()
                    {
                        Id = model.Id,
                        Weight = model.Weight,
                        Destination = model.Destination
                    };
                    var result = await ShippingContainerService.Create(container);
                    return RedirectToAction("Index");
                }
            }
            return View("Create", model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await ShippingContainerService.GetContainers(id);
            ShippingContainerRegisterViewModel container = new ShippingContainerRegisterViewModel()
            {
                Id = id,
                Weight = result.Weight,
                Destination = result.Destination,       
            };
            return View(container);
        }
        [HttpPost]
        public async Task<IActionResult> UpDate(ShippingContainerRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Weight <= 10000)
                {
                    ShippingContainer container = new ShippingContainer()
                    {
                        Id = model.Id,
                        Weight = model.Weight,
                        Destination = model.Destination
                    };
                    var result = await ShippingContainerService.Update(container);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var result = await ShippingContainerService.GetContainers(id);
            ShippingContainerRegisterViewModel container = new ShippingContainerRegisterViewModel()
            {
                Id = id,
                Weight = result.Weight,
                Destination = result.Destination,
            };
            return View(container);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var container = await ShippingContainerService.GetContainers(id);
            await ShippingContainerService.Delete(container);
            return RedirectToAction("Index");
        }
    }
}
