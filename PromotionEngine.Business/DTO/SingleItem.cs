using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.DTO
{
    public class SingleItem
    {
        public int ItemCount { get; set; }
        public string SKU { get; set; }
        public double PricePerItem { get; set; }
        public double TotalPrice { get; set; }
    }
}
