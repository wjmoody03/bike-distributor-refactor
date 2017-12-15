using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class BikeTest
    {
        [TestMethod]
        public void TotalPriceCalculatedCorrectlyWithNoAddons()
        {
            Bike Defy = new Bike("Giant", "Defy 1", Bike.OneThousand);
            Assert.AreEqual(Bike.OneThousand, Defy.PriceWithAddons);
        }
        [TestMethod]
        public void TotalPriceCalculatedCorrectlyWithAddons()
        {
            Bike Defy = new Bike("Giant", "Defy 1", Bike.OneThousand);
            //upgrade it
            Defy.Addons.Add(Addons.AeroWheels);
            Defy.Addons.Add(Addons.ElectronicShifters);
            Assert.AreEqual(Defy.BasePrice + Addons.AeroWheels.Price + Addons.ElectronicShifters.Price, Defy.PriceWithAddons);
        }
    }
}
