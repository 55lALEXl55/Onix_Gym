using System.ComponentModel.DataAnnotations;

namespace Onix_Gym.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int IdUser { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int SupplierId { get; set; } 
        public Supplier? Supplier { get; set; }

        public ICollection<SaleDetail>? SaleDetails { get; set; }
        public ICollection<HistorialPrice>? HistorialPrices { get; set; }
    }
}
