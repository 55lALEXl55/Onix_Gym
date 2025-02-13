using System.ComponentModel.DataAnnotations;

namespace Onix_Gym.Models
{
    public class HistorialPrice
    {
        [Key]
        public int HistorialPriceId { get; set; }
        public double Price { get; set; }
        public DateTime RegisterDate { get; set; }
        public int IdUser { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
