

using System.ComponentModel.DataAnnotations;

namespace VentasDemo.Models.ViewModels
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid price.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid stock quantity.")]
        public int Stock { get; set; }
    }
}