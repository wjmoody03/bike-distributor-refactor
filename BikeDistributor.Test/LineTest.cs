using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class LineTest
    {
        private readonly static Bike Defy = new Bike("Giant", "Defy 1", Bike.OneThousand);
        private readonly static Bike Elite = new Bike("Specialized", "Venge Elite", Bike.TwoThousand);
        private readonly static Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", Bike.FiveThousand);


        [TestMethod]
        public void TotalPriceOfLineWithOneThousandDollarBikeAndQuantityOver19()
        {
            var line = new Line(Defy, 20);
            var lineAmount = line.PriceOfLineWithDiscounts();
            Assert.AreEqual(Defy.PriceWithAddons * line.Quantity * .9, lineAmount);
        }
        [TestMethod]
        public void TotalPriceOfLineWithOneThousandDollarBikeAndQuantityLessThan20()
        {
            var line = new Line(Defy, 19);
            var lineAmount = line.PriceOfLineWithDiscounts();
            Assert.AreEqual(Defy.PriceWithAddons * line.Quantity, lineAmount);
        }
        [TestMethod]
        public void TotalPriceOfLineWithTwoThousandDollarBikeAndQuantityOver9()
        {
            var line = new Line(Elite, 10);
            var lineAmount = line.PriceOfLineWithDiscounts();
            Assert.AreEqual(Elite.PriceWithAddons * line.Quantity * .8, lineAmount);
        }
        [TestMethod]
        public void TotalPriceOfLineWithTwoThousandDollarBikeAndQuantityLessThan10()
        {
            var line = new Line(Elite, 9);
            var lineAmount = line.PriceOfLineWithDiscounts();
            Assert.AreEqual(Elite.PriceWithAddons * line.Quantity, lineAmount);
        }
        [TestMethod]
        public void TotalPriceOfLineWithFiveThousandDollarBikeAndQuantityOver4()
        {
            var line = new Line(DuraAce, 5);
            var lineAmount = line.PriceOfLineWithDiscounts();
            Assert.AreEqual(DuraAce.PriceWithAddons * line.Quantity * .8, lineAmount);
        }
        [TestMethod]
        public void TotalPriceOfLineWithFiveThousandDollarBikeAndQuantityLessThan5()
        {
            var line = new Line(DuraAce, 4);
            var lineAmount = line.PriceOfLineWithDiscounts();
            Assert.AreEqual(DuraAce.PriceWithAddons * line.Quantity, lineAmount);
        }
        [TestMethod]
        public void MultiplePossibleDiscountsChoosesOnlyBestForCustomer()
        {
            var line = new Line(DuraAce, 21);
            var lineAmount = line.PriceOfLineWithDiscounts();
            //make sure we got the 20% discount for 5k bikes, not the 10% discount for 1k bikes
            //this will also test that only one discount was applied.
            Assert.AreEqual(DuraAce.PriceWithAddons * line.Quantity * .8, lineAmount);
        }
    }
}
