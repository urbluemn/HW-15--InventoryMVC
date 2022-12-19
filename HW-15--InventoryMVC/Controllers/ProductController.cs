using HW_14__InventoryAPI.Models;
using HW_14__InventoryAPI.Services;
using HW_15__InventoryMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW_14__InventoryAPI.Controllers
{
    [Controller]
    //[Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        ActionWithProductService actionService;

        public ProductController(ActionWithProductService action)
        {
            this.actionService = action;
        }
        [HttpGet]
        public IActionResult IndexUpdated()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewByType(string type)
        {
            return Ok(actionService.ViewByType(type));
        }

        [HttpGet]
        public IActionResult ViewAllProducts()
        {
            return View(actionService.ViewAllProducts());
        }

        [HttpGet]
        public IActionResult CountInventorySum()
        {
            return View(actionService.CountInvSum());
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel product)
        {
            actionService.AddProductToList(product);
            return Created($"Created {product.Name}", product);
        }

        [HttpGet]
        public IActionResult Edit(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var ProductModel = actionService.FindByIndex(Id);
            if (ProductModel == null)
            {
                return NotFound();
            }
            return View(ProductModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel productModel)
        {
            actionService.ReplaceProduct(productModel);
            return RedirectToAction("ViewAllProducts");
        }
    }
}
