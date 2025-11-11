

using System.ComponentModel.DataAnnotations;

namespace VentasDemo.Models.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid price.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid stock quantity.")]
        public int Stock { get; set; }
    }
}