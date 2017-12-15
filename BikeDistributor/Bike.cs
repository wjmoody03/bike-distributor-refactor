using System.Collections.Generic;
using System.Linq;

namespace BikeDistributor
{
    public class Bike
    {
        public const int OneThousand = 1000;
        public const int TwoThousand = 2000;
        public const int FiveThousand = 5000;

        public Bike(string brand, string model, int basePrice)
        {
            Brand = brand;
            Model = model;
            BasePrice = basePrice;
            Addons = new List<Addon>();
        }

        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int BasePrice { get; set; }
        public IList<Addon> Addons { get; set; }
        public int PriceWithAddons
        {
            get
            {
                return BasePrice + Addons.Sum(a => a.Price);
            }
        }

    }
}
