using System.ComponentModel.DataAnnotations;

namespace Onix_Gym.Models
{
    public class HistorialSale
    {
        [Key]
        public int HistorialSaleId {  get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public int IdUser { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; } 
    }
}
