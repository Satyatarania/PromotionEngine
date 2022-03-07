using PromotionEngine.Business.DTO;
using PromotionEngine.DataAccess;
using PromotionEngine.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Business.Service
{
    public class MultipleDiscount : ICalculationDiscountService
    {
        public BundleItem CalculateDiscount(CalculateOrderItemsDTO rulesDTO, Promotion promotion)
        {
            double priceBeforeDiscount = 0.0;
            double priceAfterDiscount = 0.0;

            if (promotion.DiscountType == DiscountType.FixedPrice)
            {
                priceBeforeDiscount = promotion.Quantity * rulesDTO.BundleCount * rulesDTO.ItemForProccessing.First().Price;
                priceAfterDiscount = promotion.FixedPriceDiscount * rulesDTO.BundleCount;
            }
            else
            {
                priceBeforeDiscount = rulesDTO.ItemForProccessing.Sum(item => item.Price * item.Quantity);
                priceAfterDiscount = priceBeforeDiscount - priceBeforeDiscount * promotion.PercentageDiscount / 100;
            }

            return new MultipleBundleItem()
            {
                DiscountType = promotion.DiscountType,
                Count = rulesDTO.BundleCount,
                SKU = rulesDTO.ItemForProccessing.FirstOrDefault().SKU,
                PromotionDiscount = priceBeforeDiscount - priceAfterDiscount,
                Amount = priceAfterDiscount
            };
        }
    }
}
