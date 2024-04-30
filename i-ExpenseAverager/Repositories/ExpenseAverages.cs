using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverages
    {
        private List<ExpenseAverage> expenseAverages = new List<ExpenseAverage>();

        public void Add(ExpenseAverage expenseAverage)
        {
            expenseAverages.Add(expenseAverage);
        }
        public void Remove(ExpenseAverage expenseAverage)
        {
            expenseAverages.Remove(expenseAverage);
        }

        public void Remove(int expenseAverageID)
        {
            ExpenseAverage expenseAverage = expenseAverages.Where(o => o.ExpenseAverageID.Equals(expenseAverageID)).FirstOrDefault();
            expenseAverages.Remove(expenseAverage);
        }

        public IEnumerable<ExpenseAverage> Where(Func<ExpenseAverage, bool> predicate)
        {
            return (IEnumerable<ExpenseAverage>)expenseAverages.Where(predicate);
        }

        public ExpenseAverage FirstOrDefault(Func<ExpenseAverage, bool> predicate)
        {
            return expenseAverages.FirstOrDefault(predicate);
        }

        public List<ExpenseAverage> ToList()
        {
            return expenseAverages;
        }
    }
}
