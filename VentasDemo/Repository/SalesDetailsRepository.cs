
using Microsoft.EntityFrameworkCore;
using VentasDemo.Models;
using VentasDemo.Repository.Interfaces;

namespace VentasDemo.Repository
{
    public class SalesDetailsRepository : ISalesDetailsRepository, IDisposable
    {

        private ApplicationDbContext _context;

        private bool disposed = false;

        public SalesDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddSaleDetail(SaleDetails saleDetail)
        {
            _context.SaleDetails.Add(saleDetail);
            _context.SaveChanges();
        }

        public void DeleteSaleDetail(int id)
        {
            var saleDetail = _context.SaleDetails.Find(id);
            if (saleDetail != null)
            {
                _context.SaleDetails.Remove(saleDetail);
                _context.SaveChanges();
            }
        }

        public IEnumerable<SaleDetails> GetAllSalesDetails()
        {
            return _context.SaleDetails.ToList();
        }

        public SaleDetails? GetSaleDetailById(int id)
        {
            return _context.SaleDetails.Find(id);
        }

        public IEnumerable<SaleDetails> GetSalesDetailsBySaleId(int saleId)
        {
            return _context.SaleDetails.Where(sd => sd.SaleId == saleId).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateSaleDetail(SaleDetails saleDetail)
        {
            throw new NotImplementedException();
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