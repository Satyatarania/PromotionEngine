using PromotionEngine.Business.Calculators;
using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.Service
{
    public interface ICalculatorTypeService
    {
        CalculateBase GetCalculatorType(Promotion promotion);
        DefaultBase GetDefaultCalculator(List<Promotion> promotions);
    }
}
