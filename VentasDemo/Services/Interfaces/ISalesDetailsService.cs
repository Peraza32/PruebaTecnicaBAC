using VentasDemo.Models;

namespace VentasDemo.Services.Interfaces
{
    public interface ISalesDetailsService
    {
        SaleDetails addSaleDetails(SaleDetails saleDetails);
        List<SaleDetails> getSaleDetailsBySaleId(int saleId);
        void deleteSaleDetails(int saleDetailsId);
        List<SaleDetails> getAllSalesDetails();
        SaleDetails? getSaleDetailbyId(int saleDetailId);

    }
}