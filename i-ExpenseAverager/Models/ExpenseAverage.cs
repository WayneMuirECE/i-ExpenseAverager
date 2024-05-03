using System.Xml.Linq;

namespace i_ExpenseAverager.Models
{
    public class ExpenseAverage
    {
        public int ExpenseAverageID { get; set; }
        public int ExpenseAverageTypeID { get; set; }
        public int ExpenseLocationID { get; set; }
        public int ExpenseOccasionID { get; set; }
        public DateTime Date { get; set; }
        public double ExpenseAverageAmount { get; set; }
        public string Note { get; set; }

        public static readonly string TagName = "expenseaverage";

        public ExpenseAverage(int expenseAverageID, int expenseAverageTypeID, int expenseLocationID, int expenseOccasionID, DateTime date, double expenseAverageAmount, string note)
        {
            ExpenseAverageID = expenseAverageID;
            ExpenseAverageTypeID = expenseAverageTypeID;
            ExpenseLocationID = expenseLocationID;
            ExpenseOccasionID = expenseOccasionID;
            Date = date;
            ExpenseAverageAmount = expenseAverageAmount;
            Note = note;
        }

        public ExpenseAverage(XElement xml)
        {
            ExpenseAverageID = int.Parse(xml.Attribute("id").Value);
            ExpenseAverageTypeID = int.Parse(xml.Attribute("uid").Value);
            ExpenseLocationID = int.Parse(xml.Attribute("locid").Value);
            ExpenseOccasionID = int.Parse(xml.Attribute("occid").Value);
            Date = DateTime.Parse(xml.Attribute("date").Value);
            ExpenseAverageAmount = double.Parse(xml.Attribute("am").Value);
            Note = xml.Attribute("note").Value;
        }

        public XElement AsXML() => new XElement(TagName,
            new XAttribute("id", ExpenseAverageID.ToString()),
            new XAttribute("uid", ExpenseAverageTypeID.ToString()),
            new XAttribute("locid", ExpenseLocationID.ToString()),
            new XAttribute("occid", ExpenseOccasionID.ToString()),
            new XAttribute("date", Date.ToShortDateString()),
            new XAttribute("am", ExpenseAverageAmount),
            new XAttribute("note", Note));
    }
}
