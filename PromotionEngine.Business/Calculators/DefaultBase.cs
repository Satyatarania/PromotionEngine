using PromotionEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.Calculators
{
    public abstract class DefaultBase : CalculateBase
    {
        public List<Promotion> Promotions { get; set; }

        public DefaultBase(List<Promotion> promotions)
        {
            Promotions = promotions;
        }
    }
}
