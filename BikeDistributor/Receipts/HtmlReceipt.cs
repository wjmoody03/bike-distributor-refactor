using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Receipts
{
    public class HtmlReceipt: ReceiptBase, IReceipt
    {
        public HtmlReceipt(Order order) : base(order) { }

        protected override void WriteHeader()
        {
            this._receiptContents.Append($"<html><body><h1>Order Receipt for {_order.Company}</h1>");
        }
        protected override void WriteLines(IList<Line> lines)
        {
            this._receiptContents.Append("<ul>");
            base.WriteLines(lines);
            this._receiptContents.Append("</ul>");
        }

        protected override string WriteLine(Line line)
        {
            return $"<li>{line.Description} = {line.PriceOfLineWithDiscounts().ToString("C")}</li>";
        }
        protected override void WriteFooter()
        {
            var tax = _order.TaxRate * _subtotal;
            this._receiptContents.Append($"<h3>Sub-Total: {_subtotal.ToString("C")}</h3>");
            this._receiptContents.Append($"<h3>Tax: {tax.ToString("C")}</h3>");
            this._receiptContents.Append($"<h2>Total: {(tax+_subtotal).ToString("C")}</h2>");
            this._receiptContents.Append("</body></html>");
        }
    }
}
