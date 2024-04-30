using System.Xml.Linq;

namespace i_ExpenseAverager.Models
{
    public class ExpenseAverage
    {
        private int expenseAverageID;
        private int expenseAverageTypeID;
        private DateTime date;
        private double expenseAverageAmount;
        private string note;

        public static readonly string TagName = "expenseaverage";

        public int ExpenseAverageID
        {
            get
            {
                return expenseAverageID;
            }
        }

        public int ExpenseAverageTypeID
        {
            get
            {
                return expenseAverageTypeID;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public double ExpenseAverageAmount
        {
            get
            {
                return this.expenseAverageAmount;
            }
            set
            {
                this.expenseAverageAmount = value;
            }
        }

        public string Note
        {
            get
            {
                return this.note;
            }
            set
            {
                this.note = value;
            }
        }

        public ExpenseAverage(int expenseAverageID, int expenseAverageTypeID, DateTime date, double expenseAverageAmount, string note)
        {
            this.expenseAverageID = expenseAverageID;
            this.expenseAverageTypeID = expenseAverageTypeID;
            this.date = date;
            this.expenseAverageAmount = expenseAverageAmount;
            this.note = note;
        }
        /// <summary>
        /// Converts a expenseAverage XElement into a expenseAverage object.
        /// </summary>
        /// <param name="xml"></param>
        public ExpenseAverage(XElement xml)
        {
            expenseAverageID = int.Parse(xml.Attribute("id").Value);
            expenseAverageTypeID = int.Parse(xml.Attribute("uid").Value);
            date = DateTime.Parse(xml.Attribute("date").Value);
            expenseAverageAmount = double.Parse(xml.Attribute("am").Value);
            note = xml.Attribute("note").Value;
        }

        public XElement AsXML()
        {
            XElement self = new XElement(ExpenseAverage.TagName, new XAttribute("id", expenseAverageID.ToString()), new XAttribute("uid", expenseAverageTypeID.ToString()),
                new XAttribute("date", date.ToShortDateString()), new XAttribute("am", expenseAverageAmount), new XAttribute("note", note));

            return self;
        }
    }
}
