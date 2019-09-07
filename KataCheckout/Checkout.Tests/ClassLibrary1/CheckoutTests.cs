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
            Assert.IsTrue(checkOut.Total() == 2.70m);
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




    }
}
