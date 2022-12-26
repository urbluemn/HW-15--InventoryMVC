using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace HW_15__InventoryMVC.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int Amount { get; set; }
        //[DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        //[Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public ProductModel() { }

        public ProductModel(string name, string type, int amount, decimal price, Guid guid)
        {
            Id = guid;
            Name = name;
            Type = type;
            Amount = amount;
            Price = price;
        }

        


    }
}
