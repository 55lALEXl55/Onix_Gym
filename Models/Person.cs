using Onix_Gym.Models;
using System.ComponentModel.DataAnnotations;

namespace Onix_Gym.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string Name { get; set; }
        public string? CI { get; set; }
        public int? PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public char? Gender { get; set; }
        public int Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int IdUser { get; set; }
        public Employe Employe { get; set; }

        public ICollection<Sale> Purchases { get; set; }
    }
}


