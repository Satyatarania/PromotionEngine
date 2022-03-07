using System;
using System.Collections.Generic;
using System.Text;
using PromotionEngine.DataAccess;

namespace PromotionEngine.Business.DTO
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }

        public List<OrderItem> Items { get; set; }
    }
}
