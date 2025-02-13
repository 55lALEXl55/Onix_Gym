using System.ComponentModel.DataAnnotations;

namespace Onix_Gym.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int Status {  get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int IdUser { get; set; }

        public int EmployeId { get; set; } 
        public Employe Employe { get; set; } 
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
