using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onix_Gym.Models
{
    public class Employe
    {
        public int EmployeId { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string Name { get; set; }
        public string CI { get; set; }
        public int? PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public char Gender { get; set; }
        public int Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int IdUser { get; set; }

        public DateTime AdmissionDate { get; set; }
        public double? Salary { get; set; }

        // Relación con User
        public int UserId { get; set; }
        public User User { get; set; }

        // Relación con Sale (ventas realizadas como empleado)
        public ICollection<Sale> Sales { get; set; }
    }
}
