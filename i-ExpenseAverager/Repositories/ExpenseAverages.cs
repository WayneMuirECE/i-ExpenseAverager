using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverages
    {
        private List<ExpenseAverage> _expenseAverages = new List<ExpenseAverage>();

        public void Add(ExpenseAverage expenseAverage) => _expenseAverages.Add(expenseAverage);

        public void Remove(ExpenseAverage expenseAverage) => _expenseAverages.Remove(expenseAverage);

        public void Remove(int expenseAverageID) => _expenseAverages.RemoveAll(e => e.ExpenseAverageID == expenseAverageID);

        public IEnumerable<ExpenseAverage> Where(Func<ExpenseAverage, bool> predicate) => _expenseAverages.Where(predicate);

        public ExpenseAverage FirstOrDefault(Func<ExpenseAverage, bool> predicate) => _expenseAverages.FirstOrDefault(predicate);

        public List<ExpenseAverage> ToList() => _expenseAverages;
    }

}
