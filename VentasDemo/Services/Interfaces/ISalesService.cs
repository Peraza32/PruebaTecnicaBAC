using VentasDemo.Models;

namespace VentasDemo.Services.Interfaces
{
    public interface ISalesService
    {
        Sale addSale(int productId, int quantity);
        Sale getSalebyId(int saleId);

        List<Sale> getAllSales();
    }
}