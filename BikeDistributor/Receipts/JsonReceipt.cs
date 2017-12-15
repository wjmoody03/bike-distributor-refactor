using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Receipts
{
    public class JsonReceipt: ReceiptBase, IReceipt
    {
        public JsonReceipt(Order order) : base(order) { }

        protected override void WriteHeader()
        {
            this._receiptContents.Append($"{{'Description':'Order Receipt for {_order.Company}',");
        }
        protected override void WriteLines(IList<Line> lines)
        {
            this._receiptContents.Append("'Lines':[");
            base.WriteLines(lines);
            this._receiptContents.Remove(this._receiptContents.Length-1, 1); //remove trailing comma from last entry
            this._receiptContents.Append("]");
        }

        protected override string WriteLine(Line line)
        {
            return $"{{'Description':'{line.Quantity} x {line.Bike.Brand} {line.Bike.Model}','Price':{line.PriceOfLineWithDiscounts()}}},";
        }
        protected override void WriteFooter()
        {
            var tax = _order.TaxRate * _subtotal;
            this._receiptContents.Append($",'Sub-Total':{_subtotal},'Tax':{tax},Total:{(tax+_subtotal)}}}");
        }
    }
}
