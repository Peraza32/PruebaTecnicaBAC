

using VentasDemo.Models;
using VentasDemo.Services.Interfaces;

namespace VentasDemo.Services
{
    public class SalesDetailsService : ISalesDetailsService
    {
        public SaleDetails addSaleDetail(int saleId, int productId, int quantity, decimal price)
        {
            throw new NotImplementedException();
        }

        public SaleDetails addSaleDetails(int saleId, int productId, int quantity, decimal price)
        {
            throw new NotImplementedException();
        }

        public void deleteSaleDetails(int saleDetailsId)
        {
            throw new NotImplementedException();
        }

        public List<SaleDetails> getAllSalesDetails()
        {
            throw new NotImplementedException();
        }

        public SaleDetails getSaleDetailbyId(int saleDetailId)
        {
            throw new NotImplementedException();
        }

        public List<SaleDetails> getSaleDetailsBySaleId(int saleId)
        {
            throw new NotImplementedException();
        }
    }
}