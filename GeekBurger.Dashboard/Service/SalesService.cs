using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Dashboard.Service.Interfaces;
using GeekBurger.Order.Contracts;
using GeekBurger.Dashboard.Model;
using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Repository.Interfaces;

namespace GeekBurger.Dashboard.Service
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;

        public SalesService(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public async Task SaveSale(OrderChanged order)
        {
            if (order.State.ToLower() == "paid")
            {
                var sale = new Sale
                {
                    OrderDate = order.OrderTime,
                    Value = order.Total,
                    SaleId = order.OrderId,
                    StoreName = order.StoreName
                };

                await _salesRepository.Add(sale);
            }
        }


        public async Task<IEnumerable<Sales>> GetSales(SalesRequest salesRequest)
        {
            var sales = new List<Sale>();

            if (salesRequest.Per != null)
            {
                var dateRange = SetInterval(salesRequest.Per, salesRequest.Value);
                sales = await _salesRepository.GetByInterval(dateRange.start, dateRange.end);
            }
            else
            {
                sales = await _salesRepository.GetAll();
            }

            return ConsolidateSales(sales);
        }

        private static IEnumerable<Sales> ConsolidateSales(List<Sale> sales)
        {
            return sales
                .GroupBy(s => s.StoreName)
                .Select(c => new Sales
                {
                    StoreName = c.Key,
                    Total = c.Count(),
                    Value = c.Sum(s => s.Value)
                });
        }

        private static (DateTime start, DateTime end) SetInterval(string per, int value)
        {
            var date = DateTime.Now;

            (DateTime start, DateTime end) dateRange;
            dateRange.start = new DateTime();
            dateRange.end = new DateTime();

            switch (per.ToLower())
            {
                case "day":
                    dateRange.start = date.AddDays(-value);
                    dateRange.end = date;
                    break;
                case "hour":
                    dateRange.start = date.AddHours(-value);
                    dateRange.end = date;
                    break;
                case "minute":
                    dateRange.start = date.AddMinutes(-value);
                    dateRange.end = date;
                    break;
                default:
                    break;
            }

            return dateRange;
        }
    }
}
