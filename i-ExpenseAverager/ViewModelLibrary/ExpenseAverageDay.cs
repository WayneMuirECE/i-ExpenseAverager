using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.ViewModelLibrary
{
    public class ExpenseAverageDay
    {
        private List<ExpenseAverage2> daysexpenses;

        public List<ExpenseAverage2> Daysexpenses
        {
            get { return daysexpenses; }
            set { daysexpenses = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get
            {
                return date;
            }
        }

        public ExpenseAverageDay(DateTime date)
        {
            this.date = date;
            this.daysexpenses = new List<ExpenseAverage2>();
        }

        public double DaysTotal
        {
            get
            {
                if (daysexpenses == null)
                {
                    return 0.00;
                }
                if (daysexpenses.Count == 0)
                {
                    return 0.00;
                }
                double total = 0.00;
                foreach (ExpenseAverage2 item in daysexpenses)
                {
                    total += item.ExpenseAverageAmount;
                }
                return total;
            }
        }

        public List<int> DaysTypes()
        {
            List<int> list = new List<int>();
            if (daysexpenses == null)
            {
                return list;
            }
            if (daysexpenses.Count == 0)
            {
                return list;
            }
            foreach (ExpenseAverage2 item in daysexpenses)
            {
                list.Add(item.ExpenseAverageTypeID);
            }
            return list;
        }
    }
}
