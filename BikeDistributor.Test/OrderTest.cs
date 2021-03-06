﻿using BikeDistributor.Receipts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BikeDistributor.Test
{
    [TestClass]
    public class OrderTest
    {
        private readonly static Bike Defy = new Bike("Giant", "Defy 1", Bike.OneThousand);
        private readonly static Bike UpgradedDefy = new Bike("Giant", "Defy 1", Bike.OneThousand, new List<Addon>() { Addons.AeroWheels });
        private readonly static Bike Elite = new Bike("Specialized", "Venge Elite", Bike.TwoThousand);
        private readonly static Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", Bike.FiveThousand);

        [TestMethod]
        public void ReceiptOneDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 1));
            Assert.AreEqual(ResultStatementOneDefy, order.Receipt(ReceiptType.PlainText));
        }

        private const string ResultStatementOneDefy = @"Order Receipt for Anywhere Bike Shop
	1 x Giant Defy 1 = $1,000.00
Sub-Total: $1,000.00
Tax: $72.50
Total: $1,072.50";

        [TestMethod]
        public void ReceiptOneUpgradedDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(UpgradedDefy, 1));
            Assert.AreEqual(ResultStatementOneUpgradedDefy, order.Receipt(ReceiptType.PlainText));
        }

        private const string ResultStatementOneUpgradedDefy = @"Order Receipt for Anywhere Bike Shop
	1 x Upgraded Giant Defy 1 = $1,100.00
Sub-Total: $1,100.00
Tax: $79.75
Total: $1,179.75";

        [TestMethod]
        public void ReceiptOneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 1));
            Assert.AreEqual(ResultStatementOneElite, order.Receipt(ReceiptType.PlainText));
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
            Assert.AreEqual(ResultStatementOneDuraAce, order.Receipt(ReceiptType.PlainText));
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
            Assert.AreEqual(HtmlResultStatementOneDefy, order.Receipt(ReceiptType.Html));
        }

        private const string HtmlResultStatementOneDefy = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Giant Defy 1 = $1,000.00</li></ul><h3>Sub-Total: $1,000.00</h3><h3>Tax: $72.50</h3><h2>Total: $1,072.50</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 1));
            Assert.AreEqual(HtmlResultStatementOneElite, order.Receipt(ReceiptType.Html));
        }

        private const string HtmlResultStatementOneElite = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized Venge Elite = $2,000.00</li></ul><h3>Sub-Total: $2,000.00</h3><h3>Tax: $145.00</h3><h2>Total: $2,145.00</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1));
            Assert.AreEqual(HtmlResultStatementOneDuraAce, order.Receipt(ReceiptType.Html));
        }

        private const string HtmlResultStatementOneDuraAce = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized S-Works Venge Dura-Ace = $5,000.00</li></ul><h3>Sub-Total: $5,000.00</h3><h3>Tax: $362.50</h3><h2>Total: $5,362.50</h2></body></html>";


        [TestMethod]
        public void JSONReceiptOneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1));
            Assert.AreEqual(JSONResultStatementOneDuraAce, order.Receipt(ReceiptType.JSON));
        }

        private const string JSONResultStatementOneDuraAce = @"{""Description"":""Order Receipt for Anywhere Bike Shop"",""Lines"":[{""Description"":""1 x Specialized S-Works Venge Dura-Ace"",""Price"":5000.0}],""Subtotal"":5000.0,""Tax"":362.5,""Total"":5362.5}";

        [TestMethod]
        public void XMLReceiptOneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1));
            Assert.AreEqual(XMLResultStatementOneDuraAce, order.Receipt(ReceiptType.XML));
        }

        private const string XMLResultStatementOneDuraAce = @"<receipt><description>Order Receipt for Anywhere Bike Shop</description><lines><line><description>1 x Specialized S-Works Venge Dura-Ace</description><price>5000</price></line></lines><subtotal>5000</subtotal><tax>362.5</tax><total>5362.5</total></receipt>";


    }

}


