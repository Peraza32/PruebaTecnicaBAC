using VentasDemo.Models;

namespace VentasDemo.Services.Interfaces
{
    public interface ISalesService
    {
        Sale addSale(Sale sale);
        Sale? getSalebyId(int saleId);

        List<Sale> getAllSales();
    }
}