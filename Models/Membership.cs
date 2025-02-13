using System.ComponentModel.DataAnnotations;

namespace Onix_Gym.Models
{
    public class Membership
    {
        [Key]
        public int MembershipId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int IdUser { get; set; }
        public ICollection<SaleMembership>? SaleMemberships { get; set; }
    }
}
