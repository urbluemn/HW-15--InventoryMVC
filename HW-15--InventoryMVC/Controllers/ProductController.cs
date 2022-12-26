using HW_15__InventoryMVC.Models;
using HW_15__InventoryMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW_15__InventoryMVC.Controllers
{
    [Controller]
    //[Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly ActionWithProductService actionService;

        public ProductController(ActionWithProductService action)
        {
            this.actionService = action;
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
