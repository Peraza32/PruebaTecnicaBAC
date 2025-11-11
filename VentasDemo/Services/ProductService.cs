

using VentasDemo.Services.Interfaces;
using VentasDemo.Models;

namespace VentasDemo.Services
{
    public class ProductService : IProductService
    {
        

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            // Implementation
        }

        public void UpdateProduct(Product product)
        {
            // Implementation
        }

        public void DeleteProduct(int id)
        {
            // Implementation
        }

        public async Task<List<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}