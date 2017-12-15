using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Receipts
{
    public enum ReceiptType
    {
        PlainText,
        Html,
        XML,
        JSON
    }
    public interface IReceipt
    {
        //although some receipt formats may implement other methods, this is 
        //the only one required by the Order class
        string GenerateReceipt(IList<Line> lines, string company, double taxRate);
    }
    public static class ReceiptFactory
    {
        public static IReceipt CreateReceipt(ReceiptType receiptType, Order order)
        {
            switch( receiptType ){
                case ReceiptType.PlainText:
                    return new PlainTextReceipt(order);
                case ReceiptType.Html:
                    return new HtmlReceipt(order);
                default:
                    throw new NotImplementedException("The receipt type you tried to generate is not currently supported by BikeDistributor.");
            }
        }
    }

    public abstract class ReceiptBase : IReceipt
    {
        /*
         *  Supporting multiple receipt formats is an exercise that could grow in scope quickly. 
         *  In order to support more complicated renderings such as PDF, razor, or image files, this 
         *  would have to be more complex than it is right now. 
         *  However, this implementation allows for easy extension of receipt formats so long 
         *  as it renders to a string. This easily facilitates XML, JSON, and both existing formats
         */
        public ReceiptBase(Order order)
        {
            _order = order;
        }

        protected Order _order;
        protected double _subtotal; //available to header/body/footer methods after calling GenerateReceipt
        protected StringBuilder _receiptContents = new StringBuilder();
        
        //virtual methods allow for descendant classes to only override the necessary methods
        protected abstract void WriteHeader();

        protected virtual void WriteLines(IList<Line> lines)
        {
            foreach (var line in lines)
            {
                _receiptContents.Append(WriteLine(line));
            }
        }

        protected abstract string WriteLine(Line line);

        protected abstract void WriteFooter();

        public virtual string GenerateReceipt(IList<Line> lines, string company, double taxRate)
        {
            _subtotal = lines.Sum(l => l.PriceOfLineWithDiscounts());
            _receiptContents.Clear(); //on the off-chance this method has been called more than once
            WriteHeader();
            WriteLines(lines);
            WriteFooter();
            return _receiptContents.ToString();
        }
    }
}
