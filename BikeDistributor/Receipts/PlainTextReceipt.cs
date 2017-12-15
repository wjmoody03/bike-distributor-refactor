using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Receipts
{
    public class PlainTextReceipt: ReceiptBase, IReceipt
    {
        public PlainTextReceipt(Order order) : base(order) { }

        protected override void WriteHeader()
        {
            this._receiptContents.AppendLine($"Order Receipt for {_order.Company}");
        }

        protected override string WriteLine(Line line)
        {
            return $"\t{line.Quantity} x {line.Bike.Brand} {line.Bike.Model} = {line.PriceOfLineWithDiscounts().ToString("C")}{Environment.NewLine}";
        }
        protected override void WriteFooter()
        {
            var tax = _order.TaxRate * _subtotal;
            this._receiptContents.AppendLine($"Sub-Total: {_subtotal.ToString("C")}");
            this._receiptContents.AppendLine($"Tax: {tax.ToString("C")}");
            this._receiptContents.Append($"Total: {(tax+_subtotal).ToString("C")}");
        }
    }
}
