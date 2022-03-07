using PromotionEngine.Business.DTO;
using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.Calculators
{
    public abstract class CalculateBase
    {
        public abstract Checkout Calculate(Checkout checkoutSummary, List<OrderItem> orderItems);
    }
}
