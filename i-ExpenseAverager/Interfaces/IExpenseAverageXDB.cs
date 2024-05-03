using i_ExpenseAverager.Models;
using i_ExpenseAverager.Repositories;

namespace i_ExpenseAverager.Interfaces
{
    public interface IExpenseAverageXDB
    {
        string AccountName { get; set; }
        DateTime StartDate { get; set; }
        ExpenseTags ExpenseTypes { get; set; }
        ExpenseTags ExpenseLocations { get; set; }
        ExpenseTags ExpenseOccasions { get; set; }
        ExpenseAverages ExpenseAverages { get; set; }

        ExpenseTag GetExpenseAverageType(int expenseAverageTypeID);
        ExpenseTag GetExpenseAverageType(string expenseAverageType);

        ExpenseTag GetExpenseLocation(int expenseLocationID);
        ExpenseTag GetExpenseLocation(string expenseLocation);

        ExpenseTag GetExpenseOccasion(int expenseOccasionID);
        ExpenseTag GetExpenseOccasion(string expenseOccasion);

        void SaveExpenseAverageType(string expenseAverageTypeName);
        void SaveExpenseLocation(string expenseLocationName);
        void SaveExpenseOccasion(string expenseOccasionName);

        bool SaveExpenseAverage(string type, string location, string occasion, DateTime forDate, double amount, string note);
        bool DeleteExpenseAverage(ExpenseAverage expense);

        List<ExpenseAverage> GetExpenseAverageForExpenseAverageType(int expenseAverageTypeID);
        ExpenseAverage GetCurrentExpenseAverageTypeLastExpenseAverage();
        bool CurrentExpenseAverageTypeSelected();
        void SaveCurrentExpenseAverageType(string expenseAverageTypeName);
        ExpenseTag GetCurrentExpenseAverageType();
        List<ExpenseTag> GetExpenseAverageTypes();

        void SubmitChanges();
    }

}
