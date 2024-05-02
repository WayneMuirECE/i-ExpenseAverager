using System.Xml.Linq;

namespace i_ExpenseAverager.Models
{
    public class ExpenseAverageType
    {
        public int ExpenseAverageTypeID { get; set; }
        public string ExpenseAverageTypeName { get; }
        public DateTime StartDate { get; set; }
        public bool CurrentExpenseAverageType { get; set; }

        public static readonly string TagName = "expenseaveragetype";

        public ExpenseAverageType(string expenseAverageTypeName, DateTime startDate)
        {
            ExpenseAverageTypeName = expenseAverageTypeName;
            StartDate = startDate;
        }

        public ExpenseAverageType(XElement xml)
        {
            ExpenseAverageTypeID = int.Parse(xml.Attribute("id").Value);
            CurrentExpenseAverageType = bool.Parse(xml.Attribute("current").Value);
            ExpenseAverageTypeName = xml.Attribute("name").Value;
            StartDate = DateTime.Parse(xml.Attribute("date").Value);
        }

        public XElement AsXML() =>
            new XElement(TagName,
                new XAttribute("id", ExpenseAverageTypeID),
                new XAttribute("name", ExpenseAverageTypeName),
                new XAttribute("date", StartDate.ToShortDateString()),
                new XAttribute("current", CurrentExpenseAverageType.ToString()));
    }

}
