using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverageTypes
    {
        private List<ExpenseAverageType> expenseAverageTypes = new List<ExpenseAverageType>();

        public void Add(ExpenseAverageType expenseAverageType)
        {
            ExpenseAverageType expenseAverageType1 = FirstOrDefault(o => o.ExpenseAverageTypeName.Equals(expenseAverageType.ExpenseAverageTypeName));
            if (expenseAverageType1 == null)
            {
                expenseAverageTypes.Add(expenseAverageType);
            }
            if (expenseAverageType.ExpenseAverageTypeID == 0)
            {
                expenseAverageType.ExpenseAverageTypeID = expenseAverageTypes.Count();
            }
        }

        public void Remove(ExpenseAverageType expenseAverageType)
        {
            expenseAverageTypes.Remove(expenseAverageType);
        }

        public void Remove(int expenseAverageTypeID)
        {
            ExpenseAverageType expenseAverageType = expenseAverageTypes.Where(o => o.ExpenseAverageTypeID.Equals(expenseAverageTypeID)).FirstOrDefault();
            expenseAverageTypes.Remove(expenseAverageType);
        }

        public IEnumerable<ExpenseAverageType> Where(Func<ExpenseAverageType, bool> predicate)
        {
            return (IEnumerable<ExpenseAverageType>)expenseAverageTypes.Where(predicate);
        }

        public ExpenseAverageType FirstOrDefault(Func<ExpenseAverageType, bool> predicate)
        {
            return expenseAverageTypes.FirstOrDefault(predicate);
        }

        public List<ExpenseAverageType> ToList()
        {
            return expenseAverageTypes;
        }

    }
}
