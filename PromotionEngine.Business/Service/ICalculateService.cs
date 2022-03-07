using PromotionEngine.Business.DTO;
using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.Service
{
    public interface ICalculateService
    {
        public Checkout CalcualteOrder(Order order, List<Promotion> promotions);
    }
}
