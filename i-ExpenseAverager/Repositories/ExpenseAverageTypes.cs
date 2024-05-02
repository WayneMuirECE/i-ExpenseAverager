using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverageTypes
    {
        private List<ExpenseAverageType> _expenseAverageTypes = new List<ExpenseAverageType>();

        public void Add(ExpenseAverageType expenseAverageType)
        {
            if (!_expenseAverageTypes.Any(o => o.ExpenseAverageTypeName.Equals(expenseAverageType.ExpenseAverageTypeName)))
            {
                _expenseAverageTypes.Add(expenseAverageType);
            }

            if (expenseAverageType.ExpenseAverageTypeID == 0)
            {
                expenseAverageType.ExpenseAverageTypeID = _expenseAverageTypes.Count;
            }
        }

        public void Remove(ExpenseAverageType expenseAverageType)
        {
            _expenseAverageTypes.Remove(expenseAverageType);
        }

        public void Remove(int expenseAverageTypeID)
        {
            ExpenseAverageType expenseAverageType = _expenseAverageTypes.FirstOrDefault(o => o.ExpenseAverageTypeID.Equals(expenseAverageTypeID));
            _expenseAverageTypes.Remove(expenseAverageType);
        }

        public IEnumerable<ExpenseAverageType> Where(Func<ExpenseAverageType, bool> predicate) => _expenseAverageTypes.Where(predicate);

        public ExpenseAverageType FirstOrDefault(Func<ExpenseAverageType, bool> predicate) => _expenseAverageTypes.FirstOrDefault(predicate);

        public List<ExpenseAverageType> ToList() => _expenseAverageTypes;
    }

}
