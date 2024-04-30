using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverages
    {
        private List<ExpenseAverage> expenceAverages = new List<ExpenseAverage>();

        public void Add(ExpenseAverage expenceAverage)
        {
            expenceAverages.Add(expenceAverage);
        }
        public void Remove(ExpenseAverage expenceAverage)
        {
            expenceAverages.Remove(expenceAverage);
        }

        public void Remove(int expenceAverageID)
        {
            ExpenseAverage expenceAverage = expenceAverages.Where(o => o.ExpenceAverageID.Equals(expenceAverageID)).FirstOrDefault();
            expenceAverages.Remove(expenceAverage);
        }

        public IEnumerable<ExpenseAverage> Where(Func<ExpenseAverage, bool> predicate)
        {
            return (IEnumerable<ExpenseAverage>)expenceAverages.Where(predicate);
        }

        public ExpenseAverage FirstOrDefault(Func<ExpenseAverage, bool> predicate)
        {
            return expenceAverages.FirstOrDefault(predicate);
        }

        public List<ExpenseAverage> ToList()
        {
            return expenceAverages;
        }
    }
}
