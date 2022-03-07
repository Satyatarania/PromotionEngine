using PromotionEngine.Business.Service;
using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.Calculators
{
    public abstract class PromotionBase : CalculateBase
    {
        private Promotion promotion;
        public PromotionBase(Promotion promotion, ICalculationBusinessLogic calculationBusinessLogic, ICalculationDiscountService discountServices)
        {
            this.promotion = promotion;
        }
    }
}
