using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverages
    {
        private List<ExpenseAverage> _list = new List<ExpenseAverage>();

        public void Add(ExpenseAverage expenseAverage) => _list.Add(expenseAverage);

        public void Remove(ExpenseAverage expenseAverage) => _list.Remove(expenseAverage);

        public void Remove(int expenseAverageID) => _list.RemoveAll(e => e.ExpenseAverageID == expenseAverageID);

        public IEnumerable<ExpenseAverage> Where(Func<ExpenseAverage, bool> predicate) => _list.Where(predicate);

        public ExpenseAverage FirstOrDefault(Func<ExpenseAverage, bool> predicate) => _list.FirstOrDefault(predicate);

        public List<ExpenseAverage> ToList() => _list;

        public List<ExpenseAverage> ToListByDate() => _list.OrderBy(o => o.Date).ToList();

        public List<ExpenseAverage> ToListForDate(DateTime date) => _list.Where(o => o.Date.Date == date.Date).ToList();

        public List<ExpenseAverage> ToListForDateCategory(DateTime date, List<ExpenseTag> tagList) =>
            _list.Where(o => o.Date.Date == date.Date && tagList.Select(t => t.ExpenseTagID).Contains(o.ExpenseAverageTypeID)).Distinct().ToList();

        public List<ExpenseAverage> ToListForDateLocation(DateTime date, List<ExpenseTag> tagList) =>
            _list.Where(o => o.Date.Date == date.Date && tagList.Select(t => t.ExpenseTagID).Contains(o.ExpenseLocationID)).Distinct().ToList();
    }
}
