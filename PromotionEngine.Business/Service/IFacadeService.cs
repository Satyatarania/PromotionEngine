using PromotionEngine.Business.DTO;
using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.Service
{
    public interface IFacadeService
    {
        string DisplayPromotions();
        public List<OrderItem> GetAllProducts();
        string CalculateOrder(Order order);
    }
}
