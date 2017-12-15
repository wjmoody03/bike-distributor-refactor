using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    public class Discount
    {
        public Discount(int minimumBikePrice, int minimumQuantity, double discountAmount)
        {
            MinimumBikePrice = minimumBikePrice;
            MinimumQuantity = minimumQuantity;
            DiscountAmount = discountAmount;
        }

        public int MinimumBikePrice { get; private set; }
        public int MinimumQuantity { get; private set; }
        public double DiscountAmount { get; private set; }

        public static IList<Discount> AllCurrentDiscounts()
        {
            //these would presumably be pulled from a database in a realistic scenario
            return new List<Discount>()
            {
                new Discount(1000,20,.1),
                new Discount(2000,10,.2),
                new Discount(5000,5,.2)
                //add new discount parameters here if necessary
            };
        }
    }
}
