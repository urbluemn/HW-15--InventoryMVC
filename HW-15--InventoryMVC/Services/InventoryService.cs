using HW_15__InventoryMVC.Models;
using Newtonsoft.Json;

namespace HW_15__InventoryMVC.Services
{
    public class InventoryService
    {
        
        public List<ProductModel> products = new List<ProductModel>();
        public InventoryService(string jsonfile) 
        {
            string jsonstring = File.ReadAllText(jsonfile);
            products = JsonConvert.DeserializeObject<List<ProductModel>>(jsonstring);
        }
    }
}
