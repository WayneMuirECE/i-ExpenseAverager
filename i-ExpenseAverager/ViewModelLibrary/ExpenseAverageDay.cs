using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.ViewModelLibrary
{
    public class ExpenseAverageDay
    {
        public List<ExpenseAverage2> DaysExpenses { get; set; }

        public DateTime Date { get; }

        public ExpenseAverageDay(DateTime date)
        {
            Date = date;
            DaysExpenses = new List<ExpenseAverage2>();
        }

        public double DaysTotal
        {
            get
            {
                if (DaysExpenses == null)
                {
                    return 0.00;
                }

                if (DaysExpenses.Count == 0)
                {
                    return 0.00;
                }

                double total = 0.00;

                foreach (ExpenseAverage2 item in DaysExpenses)
                {
                    total += item.ExpenseAverageAmount;
                }

                return total;
            }
        }

        public List<int> DaysTypes()
        {
            List<int> list = new List<int>();

            if (DaysExpenses == null)
            {
                return list;
            }

            if (DaysExpenses.Count == 0)
            {
                return list;
            }

            foreach (ExpenseAverage2 item in DaysExpenses)
            {
                list.Add(item.ExpenseAverageTypeID);
            }

            return list;
        }
    }
}
