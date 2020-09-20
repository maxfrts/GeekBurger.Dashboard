using GeekBurger.Dashboard.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Order.Contracts;

namespace GeekBurger.Dashboard.Service.Interfaces
{
    public interface ISalesService
    {
        Task<IEnumerable<Sales>> GetSales(SalesRequest salesRequest);
        Task SaveSale(OrderChanged order);
    }
}
