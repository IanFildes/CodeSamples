using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    public class Checkout
    {
        private readonly List<Item> _itemPrices = new List<Item>
        {
            new Item { SKU = "A99", UnitPrice = 0.50m },
            new Item { SKU = "B15", UnitPrice = 0.30m },
            new Item { SKU = "C40", UnitPrice = 0.60m }
        };

        private readonly List<PricingRule> _discountRules = new List<PricingRule>
        {
            new PricingRule { SKU = "A99", Quantity = 3, DiscountPrice = 1.3m },
            new PricingRule { SKU = "B15", Quantity = 2, DiscountPrice = 0.45m }
        };

        public decimal Total()
        {
            return 0m;
        }

        public bool Scan (Item item)
        {
            if (item == null)
                throw new Exception("Null parameter passed");

            throw new Exception("Not Implemented");
        }


    }
}
