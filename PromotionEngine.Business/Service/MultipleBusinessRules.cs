using PromotionEngine.Business.DTO;
using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Business.Service
{
    public class MultipleBusinessRules : ICalculationBusinessLogic
    {
        public bool ValidateOrder(List<OrderItem> orderItems, Promotion promotion)
        {
            return orderItems.Any(x => x.SKU == promotion.SKU);
        }

        public CalculateOrderItemsDTO ApplyBusinessRules(List<OrderItem> orderItems, Promotion promotion)
        {
            CalculateOrderItemsDTO calculateOrderItemsDTO = new CalculateOrderItemsDTO();

            //Get promotion orders
            var item = orderItems.FirstOrDefault(x => x.SKU == promotion.SKU);

            calculateOrderItemsDTO.BundleItemModulus = item.Quantity % promotion.Quantity;
            calculateOrderItemsDTO.BundleItemCount = item.Quantity - calculateOrderItemsDTO.BundleItemModulus;
            calculateOrderItemsDTO.BundleCount = calculateOrderItemsDTO.BundleItemCount / promotion.Quantity;

            //if there is any bundle we add for furthure processing list
            if (calculateOrderItemsDTO.BundleCount > 0)
            {
                calculateOrderItemsDTO.ItemForProccessing.Add(new OrderItem { Price = item.Price, SKU = item.SKU, Quantity = calculateOrderItemsDTO.BundleItemCount });
            }

            //we also check the modulus and insert to (non promotion list)
            if (calculateOrderItemsDTO.BundleItemModulus > 0)
            {
                calculateOrderItemsDTO.SingleItems.Add(new SingleItem { PricePerItem = item.Price, SKU = item.SKU, ItemCount = calculateOrderItemsDTO.BundleItemModulus, TotalPrice = item.Price * calculateOrderItemsDTO.BundleItemModulus });
            }

            return calculateOrderItemsDTO;
        }

    }
}
