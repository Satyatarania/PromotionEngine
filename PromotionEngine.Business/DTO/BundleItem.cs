using System;
using System.Collections.Generic;
using System.Text;
using PromotionEngine.DataAccess.Enums;

namespace PromotionEngine.Business.DTO
{
    public class BundleItem
    {
        public double PromotionDiscount { get; set; }
        public int Count { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Amount { get; set; }
    }
}
