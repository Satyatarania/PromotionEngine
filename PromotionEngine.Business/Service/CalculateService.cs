using PromotionEngine.Business.DTO;
using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.Service
{
    public class CalculateService : ICalculateService
    {
        private readonly ICalculatorTypeService _calculatorTypeService;
        public CalculateService(ICalculatorTypeService calculatorTypeService)
        {
            _calculatorTypeService = calculatorTypeService;
        }

        public Checkout CalcualteOrder(Order order, List<Promotion> promotions)
        {
            var checkoutSummary = new Checkout();

            foreach (var promotion in promotions)
            {
                checkoutSummary = _calculatorTypeService.GetCalculatorType(promotion).Calculate(checkoutSummary, order.Items);
            }

            checkoutSummary = _calculatorTypeService.GetDefaultCalculator(promotions).Calculate(checkoutSummary, order.Items);

            return checkoutSummary;
        }
    }
}
