using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.Interfaces
{
    public interface IExpenseAverage2XDB
    {
        string AccountName { get; set; }
        DateTime StartDate { get; set; }

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
        bool DeleteExpenseAverage(ExpenseAverage2 expense);

        List<ExpenseAverage2> GetExpenseAverageForExpenseAverageType(int expenseAverageTypeID);
        ExpenseAverage2 GetCurrentExpenseAverageTypeLastExpenseAverage();
        bool CurrentExpenseAverageTypeSelected();
        void SaveCurrentExpenseAverageType(string expenseAverageTypeName);
        ExpenseTag GetCurrentExpenseAverageType();
        List<ExpenseTag> GetExpenseAverageTypes();

        void SubmitChanges();
    }

}
