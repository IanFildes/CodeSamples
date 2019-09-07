using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Checkout
    {
        private readonly List<Item> _scannedItems = new List<Item>();

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

        public decimal Total(bool applyDiscounts = true)
        {
            ProductCalculator itemCalculator = new ProductCalculator(_scannedItems, _discountRules);
            return itemCalculator.Total(applyDiscounts);

            
        }

        public bool Scan (Item item)
        {
            if (item == null)
                throw new Exception("Null parameter passed");

            var registeredItem = _itemPrices.FirstOrDefault(x => x.SKU == item.SKU);

            if (registeredItem == null)
                throw new Exception("Product has not been registered in the system");

            item.UnitPrice = registeredItem.UnitPrice;

            _scannedItems.Add(item);

            return true;
        }


    }
}
