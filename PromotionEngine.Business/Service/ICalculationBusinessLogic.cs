using PromotionEngine.Business.DTO;
using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.Service
{
    public interface ICalculationBusinessLogic
    {
        bool ValidateOrder(List<OrderItem> orderItems, Promotion promotion);
        CalculateOrderItemsDTO ApplyBusinessRules(List<OrderItem> orderItems, Promotion promotion);
    }
}
