namespace Onix_Gym.Models
{
    public class SaleMembership
    {
        public int SaleId { get; set; }
        public int MembershipId { get; set; }
        public double UnitPrice { get; set; }
        public double Amount { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdUser { get; set; }

        public Sale Sale { get; set; }
        public Membership Membership { get; set; }
    }
}
