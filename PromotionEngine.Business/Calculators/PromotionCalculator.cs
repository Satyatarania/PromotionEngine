using PromotionEngine.Business.DTO;
using PromotionEngine.Business.Service;
using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Business.Calculators
{
    public class PromotionCalculator : PromotionBase
    {
        private readonly Promotion promotion;
        private readonly ICalculationDiscountService _discountService;
        private readonly ICalculationBusinessLogic _calcultationBusinessLogic;

        public PromotionCalculator(Promotion promotion, ICalculationBusinessLogic calculationBusinessLogic, ICalculationDiscountService discountServices) : base(promotion, calculationBusinessLogic, discountServices)
        {
            this.promotion = promotion;
            _calcultationBusinessLogic = calculationBusinessLogic;
            _discountService = discountServices;
        }

        public override Checkout Calculate(Checkout checkoutSummary, List<OrderItem> orderItems)
        {
            if (!_calcultationBusinessLogic.ValidateOrder(orderItems, promotion))
            {
                return checkoutSummary;
            }

            var rulesDTO = _calcultationBusinessLogic.ApplyBusinessRules(orderItems, promotion);

            if (rulesDTO.ItemForProccessing.Any())
            {
                checkoutSummary.BundleItems.Add(_discountService.CalculateDiscount(rulesDTO, promotion));
            }

            if (rulesDTO.SingleItems.Any())
            {
                checkoutSummary.SingleItems.AddRange(rulesDTO.SingleItems);
            }

            return checkoutSummary;
        }
    }
}
