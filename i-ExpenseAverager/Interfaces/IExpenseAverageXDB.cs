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

        /// <summary>
        /// Get type by ID
        /// </summary>
        /// <param name="expenseAverageTypeID">ID to search for</param>
        /// <returns>Expense Tag is found</returns>
        ExpenseTag GetExpenseAverageType(int expenseAverageTypeID);
        /// <summary>
        /// Get type by name
        /// </summary>
        /// <param name="expenseAverageType">The name to search for</param>
        /// <returns>Expense Tag is found</returns>
        ExpenseTag GetExpenseAverageType(string expenseAverageType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseLocationID"></param>
        /// <returns></returns>
        ExpenseTag GetExpenseLocation(int expenseLocationID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseLocation"></param>
        /// <returns></returns>
        ExpenseTag GetExpenseLocation(string expenseLocation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseOccasionID"></param>
        /// <returns></returns>
        ExpenseTag GetExpenseOccasion(int expenseOccasionID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseOccasion"></param>
        /// <returns></returns>
        ExpenseTag GetExpenseOccasion(string expenseOccasion);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseAverageTypeName"></param>
        void SaveExpenseAverageType(string expenseAverageTypeName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseLocationName"></param>
        void SaveExpenseLocation(string expenseLocationName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseOccasionName"></param>
        void SaveExpenseOccasion(string expenseOccasionName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="location"></param>
        /// <param name="occasion"></param>
        /// <param name="forDate"></param>
        /// <param name="amount"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        bool SaveExpenseAverage(string type, string location, string occasion, DateTime forDate, double amount, string note);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        bool DeleteExpenseAverage(ExpenseAverage expense);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseAverageTypeID"></param>
        /// <returns></returns>
        List<ExpenseAverage> GetExpenseAverageForExpenseAverageType(int expenseAverageTypeID);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ExpenseAverage GetCurrentExpenseAverageTypeLastExpenseAverage();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool CurrentExpenseAverageTypeSelected();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseAverageTypeName"></param>
        void SaveCurrentExpenseAverageType(string expenseAverageTypeName);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ExpenseTag GetCurrentExpenseAverageType();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ExpenseTag> GetExpenseAverageTypes();

        /// <summary>
        /// 
        /// </summary>
        void SubmitChanges();
    }

}
