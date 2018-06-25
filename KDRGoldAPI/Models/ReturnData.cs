using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KDRGoldAPI.Models
{
    public class ReturnData
    {
        public String Name { get; set; }
        public int year { get; set; }
        public Decimal Liters { get; set; }
        public Decimal Quantity { get; set; }
    }
}