

using VentasDemo.Models;

namespace VentasDemo.Repository.Interfaces
{
    public interface ISalesDetailsRepository
    {
        IEnumerable<SaleDetails> GetAllSalesDetails();
        IEnumerable<SaleDetails> GetSalesDetailsBySaleId(int saleId);
        SaleDetails? GetSaleDetailById(int id);
        void AddSaleDetail(SaleDetails saleDetail);
        void UpdateSaleDetail(SaleDetails saleDetail);
        void DeleteSaleDetail(int id);
        void Save();
    }
}