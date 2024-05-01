using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.ViewModelLibrary
{
    public class ExpenseAverageDay
    {
        private List<ExpenseAverage2> daysExpenses;

        public List<ExpenseAverage2> DaysExpenses
        {
            get { return daysExpenses; }
            set { daysExpenses = value; }
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
            this.daysExpenses = new List<ExpenseAverage2>();
        }

        public double DaysTotal
        {
            get
            {
                if (daysExpenses == null)
                {
                    return 0.00;
                }
                if (daysExpenses.Count == 0)
                {
                    return 0.00;
                }
                double total = 0.00;
                foreach (ExpenseAverage2 item in daysExpenses)
                {
                    total += item.ExpenseAverageAmount;
                }
                return total;
            }
        }

        public List<int> DaysTypes()
        {
            List<int> list = new List<int>();
            if (daysExpenses == null)
            {
                return list;
            }
            if (daysExpenses.Count == 0)
            {
                return list;
            }
            foreach (ExpenseAverage2 item in daysExpenses)
            {
                list.Add(item.ExpenseAverageTypeID);
            }
            return list;
        }
    }
}
