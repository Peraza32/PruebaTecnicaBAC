using Microsoft.AspNetCore.Mvc;
using VentasDemo.Services;

namespace VentasDemo.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetAllProducts();

            return View(products);
        }
    }
}