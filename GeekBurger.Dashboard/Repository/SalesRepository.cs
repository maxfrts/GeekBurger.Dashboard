using GeekBurger.Dashboard.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Dashboard.Model;
using GeekBurger.Dashboard.Data;

namespace GeekBurger.Dashboard.Repository
{
    public class SalesRepository : ISalesRepository
    {
        private DashboardContext _context;

        public SalesRepository(DashboardContext context)
        {
            _context = context;
        }

        public async Task<List<Sale>> GetAll()
        {
            return _context.Sale?
                .ToList();
        }

        public async Task<List<Sale>> GetByInterval(DateTime start, DateTime end)
        {
            return _context.Sale
                .Where(x => x.OrderDate >= start && x.OrderDate < end).ToList();
        }

        public async Task Add(Sale sale)
        {
            _context.Sale.Add(sale);
            _context.SaveChanges();
        }
    }
}
