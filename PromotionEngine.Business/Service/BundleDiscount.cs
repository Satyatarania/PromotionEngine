using PromotionEngine.Business.DTO;
using PromotionEngine.DataAccess;
using PromotionEngine.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Business.Service
{
    public class BundleDiscount : ICalculationDiscountService
    {
        public BundleItem CalculateDiscount(CalculateOrderItemsDTO rulesDTO, Promotion promotion)
        {
            double priceBeforeDiscount = 0.0;
            double priceAfterDiscount = 0.0;

            if (promotion.DiscountType == DiscountType.FixedPrice)
            {
                priceBeforeDiscount = rulesDTO.ItemForProccessing.Sum(item => item.Price * item.Quantity);
                priceAfterDiscount = promotion.FixedPriceDiscount * rulesDTO.BundleCount;
            }
            else
            {
                priceBeforeDiscount = rulesDTO.ItemForProccessing.Sum(item => item.Price * item.Quantity);
                priceAfterDiscount = priceBeforeDiscount - priceBeforeDiscount * promotion.PercentageDiscount / 100;
            }

            return new CombinationBundleItem()
            {
                DiscountType = promotion.DiscountType,
                Count = rulesDTO.ItemForProccessing.Sum(x => x.Quantity),
                SKUs = rulesDTO.ItemForProccessing.Select(x => x.SKU).ToList(),
                PromotionDiscount = priceBeforeDiscount - priceAfterDiscount,
                Amount = priceAfterDiscount
            };
        }
    }
}
