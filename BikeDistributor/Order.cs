using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeDistributor
{
    public class Order
    {
        private const double TaxRate = .0725d;
        private readonly IList<Line> _lines = new List<Line>();

        public Order(string company)
        {
            Company = company;
        }

        public string Company { get; private set; }

        public void AddLine(Line line)
        {
            _lines.Add(line);
        }

        public string Receipt()
        {
            var totalAmount = 0d;
            var result = new StringBuilder(string.Format("Order Receipt for {0}{1}", Company, Environment.NewLine));
            foreach (var line in _lines)
            {
                var thisAmount = PriceOfLineWithDiscounts(line);
                result.AppendLine(string.Format("\t{0} x {1} {2} = {3}", line.Quantity, line.Bike.Brand, line.Bike.Model, thisAmount.ToString("C")));
                totalAmount += thisAmount;
            }
            result.AppendLine(string.Format("Sub-Total: {0}", totalAmount.ToString("C")));
            var tax = totalAmount * TaxRate;
            result.AppendLine(string.Format("Tax: {0}", tax.ToString("C")));
            result.Append(string.Format("Total: {0}", (totalAmount + tax).ToString("C")));
            return result.ToString();
        }

        public string HtmlReceipt()
        {
            var totalAmount = 0d;
            var result = new StringBuilder(string.Format("<html><body><h1>Order Receipt for {0}</h1>", Company));
            if (_lines.Any())
            {
                result.Append("<ul>");
                foreach (var line in _lines)
                {
                    var thisAmount = PriceOfLineWithDiscounts(line);                    
                    result.Append(string.Format("<li>{0} x {1} {2} = {3}</li>", line.Quantity, line.Bike.Brand, line.Bike.Model, thisAmount.ToString("C")));
                    totalAmount += thisAmount;
                }
                result.Append("</ul>");
            }
            result.Append(string.Format("<h3>Sub-Total: {0}</h3>", totalAmount.ToString("C")));
            var tax = totalAmount * TaxRate;
            result.Append(string.Format("<h3>Tax: {0}</h3>", tax.ToString("C")));
            result.Append(string.Format("<h2>Total: {0}</h2>", (totalAmount + tax).ToString("C")));
            result.Append("</body></html>");
            return result.ToString();
        }

        public static double PriceOfLineWithDiscounts(Line line)
        {

            //see if this line qualifies for any of our current discounts. 
            //we want a max of one discount to apply
            //also, ordering the discounts allows us to apply the biggest discount for which the customer is eligible
            var currentDiscounts = Discount.AllCurrentDiscounts().OrderByDescending(d => d.DiscountAmount);
            foreach (var discount in Discount.AllCurrentDiscounts().OrderByDescending(d => d.DiscountAmount))
            {
                if(line.Bike.Price>=discount.MinimumBikePrice && line.Quantity >= discount.MinimumQuantity)
                {
                    return line.Quantity * line.Bike.Price * (1d-discount.DiscountAmount);
                }
            }

            return line.Quantity * line.Bike.Price; //line isn't eligible for any discounts
            
        }

    }
}
