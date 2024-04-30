using System.Xml.Linq;

namespace i_ExpenseAverager.Models
{
    public class ExpenseAverage
    {
        private int expenceAverageID;
        private int expenceAverageTypeID;
        private DateTime date;
        private double expenceAverageAmount;
        private string note;

        public static readonly string TagName = "expenceaverage";

        public int ExpenceAverageID
        {
            get
            {
                return expenceAverageID;
            }
        }

        public int ExpenceAverageTypeID
        {
            get
            {
                return expenceAverageTypeID;
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

        public double ExpenceAverageAmount
        {
            get
            {
                return this.expenceAverageAmount;
            }
            set
            {
                this.expenceAverageAmount = value;
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

        public ExpenseAverage(int expenceAverageID, int expenceAverageTypeID, DateTime date, double expenceAverageAmount, string note)
        {
            this.expenceAverageID = expenceAverageID;
            this.expenceAverageTypeID = expenceAverageTypeID;
            this.date = date;
            this.expenceAverageAmount = expenceAverageAmount;
            this.note = note;
        }
        /// <summary>
        /// Converts a expenceAverage XElement into a ExpenceAverage object.
        /// </summary>
        /// <param name="xml"></param>
        public ExpenseAverage(XElement xml)
        {
            expenceAverageID = int.Parse(xml.Attribute("id").Value);
            expenceAverageTypeID = int.Parse(xml.Attribute("uid").Value);
            date = DateTime.Parse(xml.Attribute("date").Value);
            expenceAverageAmount = double.Parse(xml.Attribute("am").Value);
            note = xml.Attribute("note").Value;
        }

        public XElement AsXML()
        {
            XElement self = new XElement(ExpenseAverage.TagName, new XAttribute("id", expenceAverageID.ToString()), new XAttribute("uid", expenceAverageTypeID.ToString()),
                new XAttribute("date", date.ToShortDateString()), new XAttribute("am", expenceAverageAmount), new XAttribute("note", note));

            return self;
        }
    }
}
