

using VentasDemo.Models;
using VentasDemo.Repository;
using VentasDemo.Services.Interfaces;

namespace VentasDemo.Services
{
    public class SalesDetailsService : ISalesDetailsService
    {
        private SalesDetailsRepository _saleDetailsRepository;

        public SalesDetailsService(SalesDetailsRepository saleDetailsRepository)
        {
            _saleDetailsRepository = saleDetailsRepository;
        }
        public SaleDetails addSaleDetails(SaleDetails saleDetails)
        {
            _saleDetailsRepository.AddSaleDetail(saleDetails);
            _saleDetailsRepository.Save();
            return saleDetails;
        }   
       

        public void deleteSaleDetails(int saleDetailsId)
        {
            _saleDetailsRepository.DeleteSaleDetail(saleDetailsId);
            _saleDetailsRepository.Save();
        }

        public List<SaleDetails> getAllSalesDetails()
        {
            return _saleDetailsRepository.GetAllSalesDetails().ToList();
        }

        public SaleDetails? getSaleDetailbyId(int saleDetailId)
        {
            return _saleDetailsRepository.GetSaleDetailById(saleDetailId);
        }

        public List<SaleDetails> getSaleDetailsBySaleId(int saleId)
        {
            return _saleDetailsRepository.GetSalesDetailsBySaleId(saleId).ToList();
        }
    }
}