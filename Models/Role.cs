using System.ComponentModel.DataAnnotations;

namespace Onix_Gym.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
