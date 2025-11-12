using VentasDemo.Models;

namespace VentasDemo.Services.Interfaces
{
    public interface ISalesDetailsService
    {
        SaleDetails addSaleDetails(int saleId, int productId, int quantity, decimal price);
        List<SaleDetails> getSaleDetailsBySaleId(int saleId);
        void deleteSaleDetails(int saleDetailsId);
    }
}