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

        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int EmployeId { get; set; }
        public Employe Employe { get; set; }

        public ICollection<SaleDetail> SaleDetails { get; set; } 
        public ICollection<SaleMembership> SaleMemberships { get; set; }
    }

}
