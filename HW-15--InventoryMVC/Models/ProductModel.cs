using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace HW_14__InventoryAPI.Models
{
    public class ProductModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Amount { get; private set; }
        [DisplayFormat(DataFormatString ="{0:n2}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; private set; }

        public ProductModel(string name, string type, int amount, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Type = type;
            Amount = amount;
            Price = price;
        }
    }
}
