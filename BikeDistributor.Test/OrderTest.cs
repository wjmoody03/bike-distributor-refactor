using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class OrderTest
    {
        private readonly static Bike Defy = new Bike("Giant", "Defy 1", Bike.OneThousand);
        private readonly static Bike Elite = new Bike("Specialized", "Venge Elite", Bike.TwoThousand);
        private readonly static Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", Bike.FiveThousand);

        [TestMethod]
        public void ReceiptOneDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 1));
            Assert.AreEqual(ResultStatementOneDefy, order.Receipt());
        }

        private const string ResultStatementOneDefy = @"Order Receipt for Anywhere Bike Shop
	1 x Giant Defy 1 = $1,000.00
Sub-Total: $1,000.00
Tax: $72.50
Total: $1,072.50";

        [TestMethod]
        public void ReceiptOneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 1));
            Assert.AreEqual(ResultStatementOneElite, order.Receipt());
        }

        private const string ResultStatementOneElite = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized Venge Elite = $2,000.00
Sub-Total: $2,000.00
Tax: $145.00
Total: $2,145.00";

        [TestMethod]
        public void ReceiptOneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1));
            Assert.AreEqual(ResultStatementOneDuraAce, order.Receipt());
        }

        private const string ResultStatementOneDuraAce = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized S-Works Venge Dura-Ace = $5,000.00
Sub-Total: $5,000.00
Tax: $362.50
Total: $5,362.50";

        [TestMethod]
        public void HtmlReceiptOneDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 1));
            Assert.AreEqual(HtmlResultStatementOneDefy, order.HtmlReceipt());
        }

        private const string HtmlResultStatementOneDefy = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Giant Defy 1 = $1,000.00</li></ul><h3>Sub-Total: $1,000.00</h3><h3>Tax: $72.50</h3><h2>Total: $1,072.50</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 1));
            Assert.AreEqual(HtmlResultStatementOneElite, order.HtmlReceipt());
        }

        private const string HtmlResultStatementOneElite = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized Venge Elite = $2,000.00</li></ul><h3>Sub-Total: $2,000.00</h3><h3>Tax: $145.00</h3><h2>Total: $2,145.00</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1));
            Assert.AreEqual(HtmlResultStatementOneDuraAce, order.HtmlReceipt());
        }

        private const string HtmlResultStatementOneDuraAce = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized S-Works Venge Dura-Ace = $5,000.00</li></ul><h3>Sub-Total: $5,000.00</h3><h3>Tax: $362.50</h3><h2>Total: $5,362.50</h2></body></html>";

        [TestMethod]
        public void TotalPriceOfLineWithOneThousandDollarBikeAndQuantityOver19()
        {
            var line = new Line(Defy, 20);
            var lineAmount = Order.PriceOfLineWithDiscounts(line);
            Assert.AreEqual(Defy.Price * line.Quantity * .9, lineAmount);
        }
        [TestMethod]
        public void TotalPriceOfLineWithOneThousandDollarBikeAndQuantityLessThan20()
        {
            var line = new Line(Defy, 19);
            var lineAmount = Order.PriceOfLineWithDiscounts(line);
            Assert.AreEqual(Defy.Price * line.Quantity, lineAmount);
        }
        [TestMethod]
        public void TotalPriceOfLineWithTwoThousandDollarBikeAndQuantityOver9()
        {
            var line = new Line(Elite, 10);
            var lineAmount = Order.PriceOfLineWithDiscounts(line);
            Assert.AreEqual(Elite.Price * line.Quantity * .8, lineAmount);
        }
        [TestMethod]
        public void TotalPriceOfLineWithTwoThousandDollarBikeAndQuantityLessThan10()
        {
            var line = new Line(Elite, 9);
            var lineAmount = Order.PriceOfLineWithDiscounts(line);
            Assert.AreEqual(Elite.Price * line.Quantity, lineAmount);
        }
        [TestMethod]
        public void TotalPriceOfLineWithFiveThousandDollarBikeAndQuantityOver4()
        {
            var line = new Line(DuraAce, 5);
            var lineAmount = Order.PriceOfLineWithDiscounts(line);
            Assert.AreEqual(DuraAce.Price * line.Quantity * .8, lineAmount);
        }
        [TestMethod]
        public void TotalPriceOfLineWithFiveThousandDollarBikeAndQuantityLessThan5()
        {
            var line = new Line(DuraAce, 4);
            var lineAmount = Order.PriceOfLineWithDiscounts(line);
            Assert.AreEqual(DuraAce.Price * line.Quantity, lineAmount);
        }
        [TestMethod]
        public void MultiplePossibleDiscountsChoosesOnlyBestForCustomer()
        {
            var line = new Line(DuraAce, 21);
            var lineAmount = Order.PriceOfLineWithDiscounts(line);
            //make sure we got the 20% discount for 5k bikes, not the 10% discount for 1k bikes
            //this will also test that only one discount was applied.
            Assert.AreEqual(DuraAce.Price * line.Quantity * .8, lineAmount);
        }
    }

}


