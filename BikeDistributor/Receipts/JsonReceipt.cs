using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BikeDistributor.Receipts
{
    public class JsonReceipt : ReceiptBase, IReceipt
    {
        public JsonReceipt(Order order) : base(order) { }

        public override string GenerateReceipt(IList<Line> lines, string company, double taxRate)
        {
            var subtotal = _subtotal = lines.Sum(l => l.PriceOfLineWithDiscounts());
            var tax = subtotal * _order.TaxRate;
            var receipt = new
            {
                Description = $"Order Receipt for {_order.Company}",
                Lines = lines.Select(l => new
                {
                    Description = $"{l.Quantity} x {l.Bike.Brand} {l.Bike.Model}",
                    Price = l.PriceOfLineWithDiscounts()
                }),
                Subtotal = subtotal,
                Tax = tax,
                Total = subtotal + tax
            };
            return JsonConvert.SerializeObject(receipt);
        }
    }
}
