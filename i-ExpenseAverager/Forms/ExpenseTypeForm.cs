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
                expenseAverageDateTimePicker.Value = expenseAverageType.StartDate;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string expenceAverageTypeName = this.expenseAverageTypeBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(expenceAverageTypeName))
            {
                MessageBox.Show(this, "No expence average type was selected." + Environment.NewLine + "Please input a expence average type.", "No Expence Average Type Found", MessageBoxButtons.OK);
                return;
            }
            DateTime date = this.expenseAverageDateTimePicker.Value;
            control.SaveCurrentExpenseAverageType(expenceAverageTypeName, date);
            cancelButton_Click(sender, e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (control.CurrentExpenseAverageTypeSelected())
            {
                this.Close();
            }
        }
    }
}
