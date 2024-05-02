using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverages2
    {
        private List<ExpenseAverage2> _list = new List<ExpenseAverage2>();

        public void Add(ExpenseAverage2 expenseAverage) => _list.Add(expenseAverage);

        public void Remove(ExpenseAverage2 expenseAverage) => _list.Remove(expenseAverage);

        public void Remove(int expenseAverageID) => _list.RemoveAll(e => e.ExpenseAverageID == expenseAverageID);

        public IEnumerable<ExpenseAverage2> Where(Func<ExpenseAverage2, bool> predicate) => _list.Where(predicate);

        public ExpenseAverage2 FirstOrDefault(Func<ExpenseAverage2, bool> predicate) => _list.FirstOrDefault(predicate);

        public List<ExpenseAverage2> ToList() => _list;

        public List<ExpenseAverage2> ToListByDate() => _list.OrderBy(o => o.Date).ToList();

        public List<ExpenseAverage2> ToListForDate(DateTime date) => _list.Where(o => o.Date.Date == date.Date).ToList();

        public List<ExpenseAverage2> ToListForDate(DateTime date, List<ExpenseTag> tagList) =>
            _list.Where(o => o.Date.Date == date.Date && tagList.Select(t => t.ExpenseTagID).Contains(o.ExpenseAverageTypeID)).Distinct().ToList();
    }
}
