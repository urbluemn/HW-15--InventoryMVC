using HW_15__InventoryMVC.Models;

namespace HW_15__InventoryMVC.Services
{
    public interface IActionWithProductService
    {
        public List<ProductModel> ViewByType(string type);
        public List<ProductModel> ViewAllProducts();
        public string CountInvSum();
        public void AddProductToList(ProductModel product);


    }
}
