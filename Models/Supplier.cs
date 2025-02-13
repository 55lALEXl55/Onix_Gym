using System.ComponentModel.DataAnnotations;

namespace Onix_Gym.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public int? PhoneNumber { get; set; }
        public int Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int IdUser { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
