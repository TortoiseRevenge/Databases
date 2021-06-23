using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View(await ShippingContainerService.GetShippingContainers());
        }
        public async Task<IActionResult> Create() {
            return View(new ShippingContainer());
        }
        [HttpPost]
        public async Task<IActionResult> Register(ShippingContainer model) {
            if (ModelState.IsValid) {
                var shippingcontainer = await ShippingContainerService.Create(model);
                return RedirectToAction("Index");
            }
            return View("Create", model);
        }

        public async Task<IActionResult> Edit(Guid id) {
            var shippingcontainer = await ShippingContainerService.GetShippingContainer(id);
            return View(shippingcontainer);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ShippingContainer model) {
            if (ModelState.IsValid) {
                var shippingcontainer = await ShippingContainerService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var shippingcontainer = await ShippingContainerService.GetShippingContainer(id);
            return View(shippingcontainer);
        }
        public async Task<IActionResult> Delete(Guid id) {
            var shippingcontainer = await ShippingContainerService.GetShippingContainer(id);
            await ShippingContainerService.Delete(shippingcontainer);
            return RedirectToAction("Index");
        }     
    }
}