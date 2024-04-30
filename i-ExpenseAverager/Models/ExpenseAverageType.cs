using System.Xml.Linq;

namespace i_ExpenceAverager.Models
{
    public class ExpenseAverageType
    {
        private int expenceAverageTypeID = 0;
        private string expenceAverageTypeName;
        private DateTime startDate;
        private bool currentExpenceAverageType = false;

        public static readonly string TagName = "expenceaveragetype";

        public int ExpenceAverageTypeID
        {
            get
            {
                return expenceAverageTypeID;
            }
            set
            {
                if (expenceAverageTypeID == 0)
                {
                    expenceAverageTypeID = value;
                }
            }
        }

        public string ExpenceAverageTypeName
        {
            get
            {
                return string.Copy(expenceAverageTypeName);
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

        public bool CurrentExpenceAverageType
        {
            get
            {
                return currentExpenceAverageType;
            }
            set
            {
                this.currentExpenceAverageType = value;
            }
        }

        public ExpenseAverageType(string expenceAverageTypeName, DateTime startDate)
        {
            this.expenceAverageTypeName = string.Copy(expenceAverageTypeName);
            this.startDate = startDate;
        }
        /// <summary>
        /// Converts a expenceAverageType XElement into a ExpenceAverageType object.
        /// </summary>
        /// <param name="xml"></param>
        public ExpenseAverageType(XElement xml)
        {
            expenceAverageTypeID = int.Parse(xml.Attribute("id").Value);
            currentExpenceAverageType = bool.Parse(xml.Attribute("current").Value);
            expenceAverageTypeName = xml.Attribute("name").Value;
            startDate = DateTime.Parse(xml.Attribute("date").Value);
        }

        public XElement AsXML()
        {
            XElement self = new XElement(ExpenseAverageType.TagName, new XAttribute("id", expenceAverageTypeID.ToString()),
                new XAttribute("name", expenceAverageTypeName), new XAttribute("date", startDate.ToShortDateString()),
                new XAttribute("current", currentExpenceAverageType.ToString()));
            return self;
        }
    }
}
