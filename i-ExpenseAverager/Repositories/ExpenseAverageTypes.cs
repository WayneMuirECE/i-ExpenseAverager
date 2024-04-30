using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverageTypes
    {
        private List<ExpenseAverageType> expenceAverageTypes = new List<ExpenseAverageType>();

        public void Add(ExpenseAverageType expenceAverageType)
        {
            ExpenseAverageType expenceAverageType1 = FirstOrDefault(o => o.ExpenseAverageTypeName.Equals(expenceAverageType.ExpenseAverageTypeName));
            if (expenceAverageType1 == null)
            {
                expenceAverageTypes.Add(expenceAverageType);
            }
            if (expenceAverageType.ExpenceAverageTypeID == 0)
            {
                expenceAverageType.ExpenceAverageTypeID = expenceAverageTypes.Count();
            }
        }

        public void Remove(ExpenseAverageType expenceAverageType)
        {
            expenceAverageTypes.Remove(expenceAverageType);
        }

        public void Remove(int expenceAverageTypeID)
        {
            ExpenseAverageType expenceAverageType = expenceAverageTypes.Where(o => o.ExpenceAverageTypeID.Equals(expenceAverageTypeID)).FirstOrDefault();
            expenceAverageTypes.Remove(expenceAverageType);
        }

        public IEnumerable<ExpenseAverageType> Where(Func<ExpenseAverageType, bool> predicate)
        {
            return (IEnumerable<ExpenseAverageType>)expenceAverageTypes.Where(predicate);
        }

        public ExpenseAverageType FirstOrDefault(Func<ExpenseAverageType, bool> predicate)
        {
            return expenceAverageTypes.FirstOrDefault(predicate);
        }

        public List<ExpenseAverageType> ToList()
        {
            return expenceAverageTypes;
        }

    }
}
