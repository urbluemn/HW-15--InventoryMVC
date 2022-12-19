using HW_14__InventoryAPI.Models;
using System.Globalization;
using static System.Net.WebRequestMethods;

namespace HW_14__InventoryAPI.Services
{
    public class ActionWithProductService
    {
        InventoryService inventoryService;
        public ActionWithProductService(InventoryService inventory)
        {
            this.inventoryService = inventory;
        }

        public ProductModel FindByIndex(Guid? Id)
        {
            return inventoryService.products.Single(x => x.Id == Id);
        }
        public void ReplaceProduct(ProductModel product)
        {
            var ProductToReplace = inventoryService.products.FindIndex(x=> x.Id == product.Id);
            inventoryService.products[ProductToReplace] = product;
        }
        public List<ProductModel> ViewByType(string type)
        {
            List<ProductModel> SortedProducts = new List<ProductModel>();
            for (int i = 0; i < inventoryService.products.Count; i++)
            {
                if (inventoryService.products[i].Type == type)
                    SortedProducts.Add(inventoryService.products[i]);
            }
            return SortedProducts;

        }

        public decimal CountInvSum()
        {
            decimal InvSum = 0M;
            for (int i = 0; i < inventoryService.products.Count; i++)
            {
                InvSum += inventoryService.products[i].Amount * inventoryService.products[i].Price;
            }

            return InvSum;
        }

        public void AddProductToList(ProductModel product)
        {
            inventoryService.products.Add(product);
        }

        public List<ProductModel> ViewAllProducts()
        {
            return inventoryService.products;
        }
    }
}
