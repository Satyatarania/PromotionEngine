using PromotionEngine.Business.DTO;
using PromotionEngine.Business.Service;
using PromotionEngine.DataAccess;
using PromotionEngine.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PromotionEngine.Test
{
    public class PromotionEngineTests
    {
        [Fact]
        public void ScenarioA()
        {
            //Arrange
            var order = new Order
            {
                Items = new List<OrderItem>
                {
                    new OrderItem { Quantity = 1, SKU = "A", Price = 50 },
                    new OrderItem { Quantity = 1, SKU = "B", Price = 30 },
                    new OrderItem { Quantity = 1, SKU = "C", Price = 20 }
                }
            };

            var promotions = new List<Promotion> {
                new Promotion { BundleType = BundleType.Multiple, SKU = "A", Quantity = 3, DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 130},
                new Promotion { BundleType = BundleType.Multiple, SKU = "B", Quantity = 2 , DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 45},
                new Promotion { BundleType = BundleType.Bundle, SKUs = new List<string> { "C", "D" }, DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 30 }
            };


            var calculatorTypeService = new CalculatorTypeService();
            var calculateService = new CalculateService(calculatorTypeService);

            //Act
            var orderResults = calculateService.CalcualteOrder(order, promotions);

            var totalSum = orderResults.SingleItems.Sum(x => x.TotalPrice) +
                orderResults.BundleItems.Sum(x => x.Amount);

            //Assert
            Assert.Equal(3, orderResults.SingleItems.Sum(x => x.ItemCount));
            Assert.Equal(100, totalSum);
        }

        [Fact]
        public void ScenarioB()
        {
            //Arrange
            var order = new Order
            {
                Items = new List<OrderItem>
                {
                    new OrderItem { Quantity = 5, SKU = "A", Price = 50 }, 
                    new OrderItem { Quantity = 5, SKU = "B", Price = 30 }, 
                    new OrderItem { Quantity = 1, SKU = "C", Price = 20 }
                }                                                         
            };

            var promotions = new List<Promotion> {
                new Promotion { BundleType = BundleType.Multiple, SKU = "A", Quantity = 3, DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 130},
                new Promotion { BundleType = BundleType.Multiple, SKU = "B", Quantity = 2 , DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 45},
                new Promotion { BundleType = BundleType.Bundle, SKUs = new List<string> { "C", "D" }, DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 30 }
            };

            var calculatorTypeService = new CalculatorTypeService();
            var calculateService = new CalculateService(calculatorTypeService);

            //Act
            var orderResults = calculateService.CalcualteOrder(order, promotions);

            //Assert
            var totalSum = orderResults.SingleItems.Sum(x => x.TotalPrice) +
                orderResults.BundleItems.Sum(x => x.Amount);

            Assert.Equal(4, orderResults.SingleItems.Sum(x => x.ItemCount));
            Assert.Equal(220, orderResults.BundleItems.Sum(x => x.Amount));
            Assert.Equal(150, orderResults.SingleItems.Sum(x => x.TotalPrice));
            Assert.Equal(370, totalSum);
        }

        [Fact]
        public void ScenarioC()
        {
            //Arrange
            var order = new Order
            {
                Items = new List<OrderItem>
                {
                    new OrderItem { Quantity = 3, SKU = "A", Price = 50 },
                    new OrderItem { Quantity = 5, SKU = "B", Price = 30 },
                    new OrderItem { Quantity = 1, SKU = "C", Price = 20 },
                    new OrderItem { Quantity = 1, SKU = "D", Price = 15 } 
                                                                         
                }
            };

            var promotions = new List<Promotion>() {
                new Promotion { BundleType = BundleType.Multiple, SKU = "A", Quantity = 3, DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 130},
                new Promotion { BundleType = BundleType.Multiple, SKU = "B", Quantity = 2 , DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 45},
                new Promotion { BundleType = BundleType.Bundle, SKUs = new List<string> { "C", "D" }, DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 30 }
            };


            var calculatorTypeService = new CalculatorTypeService();
            var calculateService = new CalculateService(calculatorTypeService);

            //Act
            var orderResults = calculateService.CalcualteOrder(order, promotions);

            //Assert
            var totalSum = orderResults.SingleItems.Sum(x => x.TotalPrice) +
                orderResults.BundleItems.Sum(x => x.Amount);

            Assert.Equal(1, orderResults.SingleItems.Sum(x => x.ItemCount));
            Assert.Equal(250, orderResults.BundleItems.Sum(x => x.Amount));
            Assert.Equal(30, orderResults.SingleItems.Sum(x => x.TotalPrice));
            Assert.Equal(280, totalSum);
        }
    }
}
