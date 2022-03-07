using PromotionEngine.Business.Calculators;
using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.Service
{
    public class CalculatorTypeService : ICalculatorTypeService
    {
        public CalculateBase GetCalculatorType(Promotion promotion)
        {
            if (promotion.BundleType == DataAccess.Enums.BundleType.Bundle)
            {
                return new PromotionCalculator(promotion, new BundleBusinessRules(), new BundleDiscount());
            }
            else
            {
                return new PromotionCalculator(promotion, new MultipleBusinessRules(), new MultipleDiscount());
            }
        }

        public DefaultBase GetDefaultCalculator(List<Promotion> promotions)
        {
            return new DefaultCalculator(promotions);
        }
    }
}
