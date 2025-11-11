namespace VentasDemo.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<SaleDetails> SaleDetails { get; set; }
    }
}