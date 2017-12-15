using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BikeDistributor.Receipts;

namespace BikeDistributor
{
    public class Order
    {
        public double TaxRate => .0725d;
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

        public string Receipt(Receipts.ReceiptType receiptType)
        {
            var receipt = ReceiptFactory.CreateReceipt(receiptType, this);
            return receipt.GenerateReceipt(this._lines, this.Company, this.TaxRate);
        }

    }
}
