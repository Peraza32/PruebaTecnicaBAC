
using Microsoft.EntityFrameworkCore;
using VentasDemo.Models;
using VentasDemo.Repository.Interfaces;

namespace VentasDemo.Repository
{
    public class SaleRepository : ISalesRepository, IDisposable
    {

        private ApplicationDbContext _context;

        private bool disposed = false;

        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Sale AddSale(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
            return sale;
        }

        public void DeleteSale(int id)
        {
            var sale = _context.Sales.Find(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return _context.Sales.ToList();
        }

        public Sale? GetSaleById(int id)
        {
            return _context.Sales.Find(id);
        }

        public Sale? GetSaleWithDetails(int id)
        {
            return _context.Sales.Include(s => s.SaleDetails).FirstOrDefault(s => s.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateSale(Sale sale)
        {
            _context.Sales.Update(sale);
            _context.SaveChanges();
        }

         protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}