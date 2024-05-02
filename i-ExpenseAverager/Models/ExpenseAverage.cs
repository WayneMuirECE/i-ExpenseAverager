using System.Xml.Linq;

namespace i_ExpenseAverager.Models
{
    public class ExpenseAverage
    {
        public static readonly string TagName = "expenseaverage";

        public int ExpenseAverageID { get; }
        public int ExpenseAverageTypeID { get; }
        public DateTime Date { get; set; }
        public double ExpenseAverageAmount { get; set; }
        public string Note { get; set; }

        public ExpenseAverage(int expenseAverageID, int expenseAverageTypeID, DateTime date, double expenseAverageAmount, string note)
        {
            ExpenseAverageID = expenseAverageID;
            ExpenseAverageTypeID = expenseAverageTypeID;
            Date = date;
            ExpenseAverageAmount = expenseAverageAmount;
            Note = note;
        }

        public ExpenseAverage(XElement xml)
        {
            ExpenseAverageID = int.Parse(xml.Attribute("id").Value);
            ExpenseAverageTypeID = int.Parse(xml.Attribute("uid").Value);
            Date = DateTime.Parse(xml.Attribute("date").Value);
            ExpenseAverageAmount = double.Parse(xml.Attribute("am").Value);
            Note = xml.Attribute("note").Value;
        }

        public XElement AsXML() =>
            new XElement(TagName,
                new XAttribute("id", ExpenseAverageID),
                new XAttribute("uid", ExpenseAverageTypeID),
                new XAttribute("date", Date.ToShortDateString()),
                new XAttribute("am", ExpenseAverageAmount),
                new XAttribute("note", Note));
    }

}
