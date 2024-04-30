using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.ViewModelLibrary
{
    public class ExpenseAverageDay
    {
        private List<ExpenseAverage2> daysExpences;

        public List<ExpenseAverage2> DaysExpences
        {
            get { return daysExpences; }
            set { daysExpences = value; }
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
            this.daysExpences = new List<ExpenseAverage2>();
        }

        public double DaysTotal
        {
            get
            {
                if (daysExpences == null)
                {
                    return 0.00;
                }
                if (daysExpences.Count == 0)
                {
                    return 0.00;
                }
                double total = 0.00;
                foreach (ExpenseAverage2 item in daysExpences)
                {
                    total += item.ExpenceAverageAmount;
                }
                return total;
            }
        }

        public List<int> DaysTypes()
        {
            List<int> list = new List<int>();
            if (daysExpences == null)
            {
                return list;
            }
            if (daysExpences.Count == 0)
            {
                return list;
            }
            foreach (ExpenseAverage2 item in daysExpences)
            {
                list.Add(item.ExpenceAverageTypeID);
            }
            return list;
        }
    }
}
