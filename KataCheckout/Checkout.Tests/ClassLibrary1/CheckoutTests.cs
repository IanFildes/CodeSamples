using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Tests
{
    public class CheckoutTests
    {
        [TestCase("A99")]
        [TestCase("B15")]
        public void HasExpectedItemScanned(string productCode)
        {
            var item = new Item() { SKU = productCode };
            var checkOut = new Checkout();
            Assert.IsTrue(checkOut.Scan(new Item() { SKU = productCode }));
        }

        [Test]
        public void  TotalsOnlyWithNoSpecialOffers()
        {
            var checkOut = new Checkout();
            checkOut.Scan(new Item() { SKU = "A99" });
            checkOut.Scan(new Item() { SKU = "A99" });
            checkOut.Scan(new Item() { SKU = "A99" });
            checkOut.Scan(new Item() { SKU = "B15" });
            checkOut.Scan(new Item() { SKU = "B15" });
            checkOut.Scan(new Item() { SKU = "C40" });
            Assert.IsTrue(checkOut.Total(false) == 2.70m);
        }

        [Test]
        public void TotalsOnlyWithSpecialOffers()
        {
            var checkOut = new Checkout();
            checkOut.Scan(new Item() { SKU = "A99" });
            checkOut.Scan(new Item() { SKU = "A99" });
            checkOut.Scan(new Item() { SKU = "A99" });
            checkOut.Scan(new Item() { SKU = "B15" });
            checkOut.Scan(new Item() { SKU = "B15" });
            checkOut.Scan(new Item() { SKU = "C40" });
            Assert.IsTrue(checkOut.Total() == 5.40m);
        }

        [Test]
        public void TotalsOnlyWithSpecialOffersDecoupled()
        {
            List<Item> products = new List<Item>()
            {   new Item() { SKU = "A99", UnitPrice = 0.50m },
                new Item() { SKU = "A99", UnitPrice = 0.50m },
                new Item() { SKU = "A99", UnitPrice = 0.50m },
                new Item() { SKU = "B15", UnitPrice = 0.30m },
                new Item() { SKU = "B15", UnitPrice = 0.30m },
                new Item() { SKU = "C40", UnitPrice = 0.60m }
            };

            List<PricingRule> discountRules = new List<PricingRule>
            {
                new PricingRule { SKU = "A99", Quantity = 3, DiscountPrice = 1.3m },
                new PricingRule { SKU = "B15", Quantity = 2, DiscountPrice = 0.45m }
            };

            var totaller = new ProductCalculator(products, discountRules);
            Assert.IsTrue(totaller.Total() == 5.40m);
        }
    }
}
