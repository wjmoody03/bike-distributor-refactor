using System.Linq;

namespace BikeDistributor
{
    public class Line
    {
        public Line(Bike bike, int quantity)
        {
            Bike = bike;
            Quantity = quantity;
        }

        public Bike Bike { get; private set; }
        public int Quantity { get; private set; }

        public double PriceOfLineWithDiscounts()
        {            
            //see if this line qualifies for any of our current discounts. 
            //we want a max of one discount to apply
            //also, ordering the discounts allows us to apply the biggest discount for which the customer is eligible
            var currentDiscounts = Discount.AllCurrentDiscounts().OrderByDescending(d => d.DiscountAmount);
            foreach (var discount in Discount.AllCurrentDiscounts().OrderByDescending(d => d.DiscountAmount))
            {
                if (this.Bike.Price >= discount.MinimumBikePrice && this.Quantity >= discount.MinimumQuantity)
                {
                    return this.Quantity * this.Bike.Price * (1d - discount.DiscountAmount);
                }
            }

            return this.Quantity * this.Bike.Price; //line isn't eligible for any discounts

        }
    }
}
