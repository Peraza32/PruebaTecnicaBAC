

using VentasDemo.Services.Interfaces;
using VentasDemo.Models;
using VentasDemo.Repository;

namespace VentasDemo.Services
{
    public class ProductService : IProductService
    {
        private ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product? GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
            _productRepository.Save();
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
            _productRepository.Save();
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
            _productRepository.Save();
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts().ToList();
        }
    }
}