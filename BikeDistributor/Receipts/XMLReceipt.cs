using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Receipts
{
    public class XMLReceipt: ReceiptBase, IReceipt
    {
        public XMLReceipt(Order order) : base(order) { }

        protected override void WriteHeader()
        {
            this._receiptContents.Append($"<receipt><description>Order Receipt for {_order.Company}</description>");
        }
        protected override void WriteLines(IList<Line> lines)
        {
            this._receiptContents.Append("<lines>");
            base.WriteLines(lines);
            this._receiptContents.Append("</lines>");
        }

        protected override string WriteLine(Line line)
        {
            return $"<line><description>{line.Quantity} x {line.Bike.Brand} {line.Bike.Model}</description><price>{line.PriceOfLineWithDiscounts()}</price></line>";
        }
        protected override void WriteFooter()
        {
            var tax = _order.TaxRate * _subtotal;
            this._receiptContents.Append($"<subtotal>{_subtotal}</subtotal><tax>{tax}</tax><total>{(tax+_subtotal)}</total></receipt>");
        }
    }
}
