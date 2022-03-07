using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.DTO
{
    public class CalculateOrderItemsDTO
    {
        public CalculateOrderItemsDTO()
        {
            ItemForProccessing = new List<OrderItem>();
            SingleItems = new List<SingleItem>();
        }
        public int BundleCount { get; set; }
        public int BundleItemModulus { get; set; }
        public int BundleItemCount { get; set; }
        public List<OrderItem> ItemForProccessing { get; set; }
        public List<SingleItem> SingleItems { get; set; }
    }
}
