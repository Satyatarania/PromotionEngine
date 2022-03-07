using PromotionEngine.Business.DTO;
using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Business.Service
{
    public class BundleBusinessRules : ICalculationBusinessLogic
    {
        public bool ValidateOrder(List<OrderItem> orderItems, Promotion promotion)
        {
            return orderItems.Any(x => promotion.SKUs.Contains(x.SKU));
        }
        public CalculateOrderItemsDTO ApplyBusinessRules(List<OrderItem> orderItems, Promotion promotion)
        {
            CalculateOrderItemsDTO calculateOrderItemsDTO = new CalculateOrderItemsDTO();

            var items = orderItems.Where(x => promotion.SKUs.Contains(x.SKU)).ToList();

            calculateOrderItemsDTO.BundleCount = items.Count > 1 ? items.Min(x => x.Quantity) : 0;

            if (calculateOrderItemsDTO.BundleCount > 0)
            {
                foreach (var item in items)
                {
                    var bundleItemModulus = item.Quantity - calculateOrderItemsDTO.BundleCount;
                    var bundleItemCount = item.Quantity - bundleItemModulus;

                    if (bundleItemModulus != 0)
                    {
                        calculateOrderItemsDTO.SingleItems.Add(new SingleItem
                        {
                            PricePerItem = item.Price,
                            SKU = item.SKU,
                            ItemCount = bundleItemModulus,
                            TotalPrice = item.Price * bundleItemModulus
                        });
                    }

                    //inserting items for calculation discount
                    calculateOrderItemsDTO.ItemForProccessing.Add(new OrderItem { Price = item.Price, SKU = item.SKU, Quantity = bundleItemCount });
                }

                return calculateOrderItemsDTO;
            }

            //if there is no bundle we check for individual item
            var modulusItem = items.FirstOrDefault();

            if (modulusItem.Quantity > 0)
            {
                calculateOrderItemsDTO.SingleItems.Add(new SingleItem
                {
                    PricePerItem = modulusItem.Price,
                    SKU = modulusItem.SKU,
                    ItemCount = modulusItem.Quantity,
                    TotalPrice = modulusItem.Price * modulusItem.Quantity
                });
            }

            return calculateOrderItemsDTO;
        }
    }
}
