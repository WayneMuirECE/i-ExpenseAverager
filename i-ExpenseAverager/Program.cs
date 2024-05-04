using i_ExpenseAverager.Forms;
using i_ExpenseAverager.Interfaces;
using i_ExpenseAverager.Repositories;

namespace i_ExpenseAverager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IExpenseAverageXDB xDB = new ExpenseAverageXDB();
            Application.Run(new AveragerMainForm(xDB));
        }
    }
}