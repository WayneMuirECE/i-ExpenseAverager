using i_ExpenseAverager.Models;
using i_ExpenseAverager.Repositories;

namespace i_ExpenseAverager.Forms
{
    public partial class ExpenseTypeForm : Form
    {
        ExpenseAverageXDB control;
        public ExpenseTypeForm(ExpenseAverageXDB viewModel)
        {
            InitializeComponent();
            this.control = viewModel;

            List<ExpenseAverageType> expenseAverageTypes = control.GetExpenseAverageTypes();
            List<string> expenseAverageTypeNames = new List<string>();
            foreach (ExpenseAverageType item in expenseAverageTypes)
            {
                expenseAverageTypeNames.Add(item.ExpenseAverageTypeName);
            }
            expenseAverageTypeBox.Items.AddRange(expenseAverageTypeNames.ToArray());
            ExpenseAverageType expenseAverageType = control.GetCurrentExpenseAverageType();
            if (expenseAverageType != null)
            {
                expenseAverageTypeBox.Text = expenseAverageType.ExpenseAverageTypeName;
                ExpenceAverageDateTimePicker.Value = expenseAverageType.StartDate;
            }
        }
    }
}
