

using VentasDemo.Models;
using VentasDemo.Repository;
using VentasDemo.Services.Interfaces;

namespace VentasDemo.Services
{
    public class SalesService : ISalesService
    {
        private SaleRepository _saleRepository;

        public SalesService(SaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public Sale addSale(Sale sale)
        {
            _saleRepository.AddSale(sale);
            _saleRepository.Save();
            return sale;
        }

        public List<Sale> getAllSales()
        {
            return _saleRepository.GetAllSales().ToList();
        }

        public Sale? getSalebyId(int saleId)
        {
            // Return sale with details when available
            return _saleRepository.GetSaleWithDetails(saleId);
        }

    }
}