using System.ComponentModel.DataAnnotations;

namespace VentasDemo.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime SaleDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        public string ClientName { get; set; }

        public List<SaleDetails> SaleDetails { get; set; }
    }
}