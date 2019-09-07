using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class ProductCalculator
    {
        private readonly IEnumerable<Item> _products;
        private readonly IEnumerable<PricingRule> _discountRules;

        public ProductCalculator(IEnumerable<Item> products, IEnumerable<PricingRule> discountRules)
        {
            _products = products;
            _discountRules = discountRules;
        }

        public decimal Total(bool applyDiscounts = true)
        {
            decimal totalPrice = 0.0m;
            var productGroups = _products.GroupBy(x => x.SKU);

            foreach (var scannedGroup in productGroups)
            {
                var groupCount = scannedGroup.Count();
                var product = scannedGroup.FirstOrDefault();
                PricingRule discount = null;
                if (applyDiscounts)
                {
                    discount = _discountRules.FirstOrDefault(x => x.SKU == scannedGroup.Key);
                }
                if (discount != null && groupCount >= discount.Quantity)
                {
                    totalPrice += discount.DiscountPrice * groupCount;
                }
                else
                {
                    totalPrice += product.UnitPrice * groupCount;
                }
            }
            return totalPrice;
        }
    }
}
