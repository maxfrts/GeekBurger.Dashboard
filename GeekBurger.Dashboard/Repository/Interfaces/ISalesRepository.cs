using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Dashboard.Model;

namespace GeekBurger.Dashboard.Repository.Interfaces
{
    public interface ISalesRepository
    {
        Task<List<Sale>> GetAll();
        Task<List<Sale>> GetByInterval(DateTime start, DateTime end);
        Task Add(Sale sale);
    }
}
