using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GeekBurger.Dashboard.Model
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public string StoreName { get; set; }
        public double Value { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
