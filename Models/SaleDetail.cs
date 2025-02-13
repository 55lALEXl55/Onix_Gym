namespace Onix_Gym.Models
{
    public class SaleDetail
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public double Amount { get; set; }
        public Sale Sale { get; set; }
        public Product Product { get; set; } 
    }
}
