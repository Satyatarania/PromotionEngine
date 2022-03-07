using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.DTO
{
    public  class Checkout
    {
        public List<BundleItem> BundleItems { get; set; }
        public List<SingleItem> SingleItems { get; set; }
        public Checkout()
        {
            BundleItems = new List<BundleItem>();
            SingleItems = new List<SingleItem>();
        }
    }
}
