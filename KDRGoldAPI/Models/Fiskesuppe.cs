using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KDRGoldAPI.Models
{
    public class Fiskesuppe
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String StockQuantity { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal CostPrice { get; set; }
        public Decimal Sales { get; set; }
        public Decimal Vat { get; set; }
        public Decimal AmountGrossProfit { get; set; }

        [Key]
        public DateTime SalesDate { get; set; }

        public Decimal AmountDl { get; set; }
    }
}