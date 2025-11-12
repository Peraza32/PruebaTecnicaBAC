

using VentasDemo.Models;

namespace VentasDemo.Repository.Interfaces
{
    public interface ISalesRepository
    {
        IEnumerable<Sale> GetAllSales();

        Sale? GetSaleById(int id);
        void AddSale(Sale sale);
        void UpdateSale(Sale sale);
        void DeleteSale(int id);
        void Save();

        Sale? GetSaleWithDetails(int id);

    }
}