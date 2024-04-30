using System.Xml.Linq;

namespace i_ExpenseAverager.Models
{
    public class ExpenseAverage2
    {
        private int expenseAverageID;
        private int expenseAverageTypeID;
        private int expenseLocationID;
        private int expenseOccasionID;
        private DateTime date;
        private double expenseAverageAmount;
        private string note;

        public static readonly string TagName = "expenseaverage";

        public int ExpenseAverageID
        {
            get { return expenseAverageID; }
            set { expenseAverageID = value; }
        }

        public int ExpenseAverageTypeID
        {
            get { return expenseAverageTypeID; }
            set { expenseAverageTypeID = value; }
        }

        public int ExpenseLocationID
        {
            get { return expenseLocationID; }
            set { expenseLocationID = value; }
        }

        public int ExpenseOccasionID
        {
            get { return expenseOccasionID; }
            set { expenseOccasionID = value; }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public double ExpenseAverageAmount
        {
            get { return this.expenseAverageAmount; }
            set { this.expenseAverageAmount = value; }
        }

        public string Note
        {
            get { return this.note; }
            set { this.note = value; }
        }

        public ExpenseAverage2(int expenseAverageID, int expenseAverageTypeID, int expenseLocationID, int expenseOccasionID, DateTime date, double expenseAverageAmount, string note)
        {
            this.expenseAverageID = expenseAverageID;
            this.expenseAverageTypeID = expenseAverageTypeID;
            this.expenseLocationID = expenseLocationID;
            this.expenseOccasionID = expenseOccasionID;
            this.date = date;
            this.expenseAverageAmount = expenseAverageAmount;
            this.note = note;
        }
        /// <summary>
        /// Converts a expenseAverage2 XElement into a expenseAverage2 object.
        /// </summary>
        /// <param name="xml"></param>
        public ExpenseAverage2(XElement xml)
        {
            expenseAverageID = int.Parse(xml.Attribute("id").Value);
            expenseAverageTypeID = int.Parse(xml.Attribute("uid").Value);
            expenseLocationID = int.Parse(xml.Attribute("locid").Value);
            expenseOccasionID = int.Parse(xml.Attribute("occid").Value);
            date = DateTime.Parse(xml.Attribute("date").Value);
            expenseAverageAmount = double.Parse(xml.Attribute("am").Value);
            note = xml.Attribute("note").Value;
        }

        public XElement AsXML()
        {
            XElement self = new XElement(ExpenseAverage2.TagName, new XAttribute("id", expenseAverageID.ToString()),
                new XAttribute("uid", expenseAverageTypeID.ToString()), new XAttribute("locid", expenseLocationID.ToString()),
                new XAttribute("occid", expenseOccasionID.ToString()), new XAttribute("date", date.ToShortDateString()),
                new XAttribute("am", expenseAverageAmount), new XAttribute("note", note));

            return self;
        }
    }

    public class expenseAverages2
    {
        private List<ExpenseAverage2> list = new List<ExpenseAverage2>();

        public void Add(ExpenseAverage2 expenseAverage)
        {
            list.Add(expenseAverage);
        }
        public void Remove(ExpenseAverage2 expenseAverage)
        {
            list.Remove(expenseAverage);
        }

        public void Remove(int expenseAverageID)
        {
            ExpenseAverage2 expenseAverage = list.Where(o => o.ExpenseAverageID.Equals(expenseAverageID)).FirstOrDefault();
            list.Remove(expenseAverage);
        }

        public IEnumerable<ExpenseAverage2> Where(Func<ExpenseAverage2, bool> predicate)
        {
            return (IEnumerable<ExpenseAverage2>)list.Where(predicate);
        }

        public ExpenseAverage2 FirstOrDefault(Func<ExpenseAverage2, bool> predicate)
        {
            return list.FirstOrDefault(predicate);
        }

        public List<ExpenseAverage2> ToList()
        {
            return list;
        }

        internal List<ExpenseAverage2> ToListByDate()
        {
            List<ExpenseAverage2> items;
            items = list.OrderBy(o => o.Date).ToList();
            return items;
        }

        internal List<ExpenseAverage2> ToListForDate(DateTime date)
        {
            List<ExpenseAverage2> items = ToListByDate();
            items = list.Where(o => o.Date.Equals(date)).ToList();
            return items;
        }

        internal List<ExpenseAverage2> ToListForDate(DateTime date, List<ExpenseTag> tagList)
        {
            List<ExpenseAverage2> items = ToListByDate();
            items = list.Where(o => o.Date.Equals(date)).ToList();
            List<ExpenseAverage2> items2 = new List<ExpenseAverage2>();
            foreach (ExpenseTag tag in tagList)
            {
                items2.AddRange(items.Where(o => o.ExpenseAverageTypeID == tag.ExpenseTagID).ToList());
            }
            items = items2.Distinct().ToList();
            return items;
        }
    }
}
