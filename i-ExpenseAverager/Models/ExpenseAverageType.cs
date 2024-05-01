using System.Xml.Linq;

namespace i_ExpenseAverager.Models
{
    public class ExpenseAverageType
    {
        private int expenseAverageTypeID = 0;
        private string expenseAverageTypeName;
        private DateTime startDate;
        private bool currentExpenseAverageType = false;

        public static readonly string TagName = "expenseaveragetype";

        public int ExpenseAverageTypeID
        {
            get
            {
                return expenseAverageTypeID;
            }
            set
            {
                if (expenseAverageTypeID == 0)
                {
                    expenseAverageTypeID = value;
                }
            }
        }

        public string ExpenseAverageTypeName
        {
            get
            {
                return string.Copy(expenseAverageTypeName);
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
            }
        }

        public bool CurrentExpenseAverageType
        {
            get
            {
                return currentExpenseAverageType;
            }
            set
            {
                this.currentExpenseAverageType = value;
            }
        }

        public ExpenseAverageType(string expenseAverageTypeName, DateTime startDate)
        {
            this.expenseAverageTypeName = string.Copy(expenseAverageTypeName);
            this.startDate = startDate;
        }
        /// <summary>
        /// Converts a expenseAverageType XElement into a expenseAverageType object.
        /// </summary>
        /// <param name="xml"></param>
        public ExpenseAverageType(XElement xml)
        {
            expenseAverageTypeID = int.Parse(xml.Attribute("id").Value);
            currentExpenseAverageType = bool.Parse(xml.Attribute("current").Value);
            expenseAverageTypeName = xml.Attribute("name").Value;
            startDate = DateTime.Parse(xml.Attribute("date").Value);
        }

        public XElement AsXML()
        {
            XElement self = new XElement(ExpenseAverageType.TagName, new XAttribute("id", expenseAverageTypeID.ToString()),
                new XAttribute("name", expenseAverageTypeName), new XAttribute("date", startDate.ToShortDateString()),
                new XAttribute("current", currentExpenseAverageType.ToString()));
            return self;
        }
    }
}
