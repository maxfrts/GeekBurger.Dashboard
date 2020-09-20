using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Dashboard.Contract
{
    public class Sales
    {
        public string StoreName { get; set; }
        public int Total { get; set; }
        public double Value { get; set; }
    }
}
