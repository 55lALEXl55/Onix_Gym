using System.ComponentModel.DataAnnotations;

namespace Onix_Gym.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public DateTime DateOrder { get; set; }
        public double Total {  get; set; }
        public int Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int IdUser { get; set; }

        public int PersonId { get; set; } // FK
        public Person Person { get; set; } // N a 1
        public int EmployeId { get; set; } // FK
        public Employe Employe { get; set; } // N a 1

        public ICollection<SaleDetail> SaleDetails { get; set; } // 1 a muchos
        public ICollection<SaleMembership> SaleMemberships { get; set; } // 1 a muchos
    }

}
