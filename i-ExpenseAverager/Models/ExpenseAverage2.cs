using System.Xml.Linq;

namespace i_ExpenseAverager.Models
{
    public class ExpenseAverage2
    {
        private int expenceAverageID;
        private int expenceAverageTypeID;
        private int expenceLocationID;
        private int expenceOccasionID;
        private DateTime date;
        private double expenceAverageAmount;
        private string note;

        public static readonly string TagName = "expenceaverage";

        public int ExpenceAverageID
        {
            get { return expenceAverageID; }
            set { expenceAverageID = value; }
        }

        public int ExpenceAverageTypeID
        {
            get { return expenceAverageTypeID; }
            set { expenceAverageTypeID = value; }
        }

        public int ExpenceLocationID
        {
            get { return expenceLocationID; }
            set { expenceLocationID = value; }
        }

        public int ExpenceOccasionID
        {
            get { return expenceOccasionID; }
            set { expenceOccasionID = value; }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public double ExpenceAverageAmount
        {
            get { return this.expenceAverageAmount; }
            set { this.expenceAverageAmount = value; }
        }

        public string Note
        {
            get { return this.note; }
            set { this.note = value; }
        }

        public ExpenseAverage2(int expenceAverageID, int expenceAverageTypeID, int expenceLocationID, int expenceOccasionID, DateTime date, double expenceAverageAmount, string note)
        {
            this.expenceAverageID = expenceAverageID;
            this.expenceAverageTypeID = expenceAverageTypeID;
            this.expenceLocationID = expenceLocationID;
            this.expenceOccasionID = expenceOccasionID;
            this.date = date;
            this.expenceAverageAmount = expenceAverageAmount;
            this.note = note;
        }
        /// <summary>
        /// Converts a expenceAverage2 XElement into a ExpenceAverage2 object.
        /// </summary>
        /// <param name="xml"></param>
        public ExpenseAverage2(XElement xml)
        {
            expenceAverageID = int.Parse(xml.Attribute("id").Value);
            expenceAverageTypeID = int.Parse(xml.Attribute("uid").Value);
            expenceLocationID = int.Parse(xml.Attribute("locid").Value);
            expenceOccasionID = int.Parse(xml.Attribute("occid").Value);
            date = DateTime.Parse(xml.Attribute("date").Value);
            expenceAverageAmount = double.Parse(xml.Attribute("am").Value);
            note = xml.Attribute("note").Value;
        }

        public XElement AsXML()
        {
            XElement self = new XElement(ExpenseAverage2.TagName, new XAttribute("id", expenceAverageID.ToString()),
                new XAttribute("uid", expenceAverageTypeID.ToString()), new XAttribute("locid", expenceLocationID.ToString()),
                new XAttribute("occid", expenceOccasionID.ToString()), new XAttribute("date", date.ToShortDateString()),
                new XAttribute("am", expenceAverageAmount), new XAttribute("note", note));

            return self;
        }
    }

    public class ExpenceAverages2
    {
        private List<ExpenseAverage2> list = new List<ExpenseAverage2>();

        public void Add(ExpenseAverage2 expenceAverage)
        {
            list.Add(expenceAverage);
        }
        public void Remove(ExpenseAverage2 expenceAverage)
        {
            list.Remove(expenceAverage);
        }

        public void Remove(int expenceAverageID)
        {
            ExpenseAverage2 expenceAverage = list.Where(o => o.ExpenceAverageID.Equals(expenceAverageID)).FirstOrDefault();
            list.Remove(expenceAverage);
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
                items2.AddRange(items.Where(o => o.ExpenceAverageTypeID == tag.ExpenceTagID).ToList());
            }
            items = items2.Distinct().ToList();
            return items;
        }
    }
}
