using i_ExpenceAverager.Models;
using i_ExpenceAverager.Repositories;

namespace i_ExpenceAverager.Forms
{
    public partial class ExpenseAverageTypeForm : Form
    {
        ExpenseAverageXDB control;
        public ExpenseAverageTypeForm(ExpenseAverageXDB viewModel)
        {
            InitializeComponent();
            this.control = viewModel;

            List<ExpenseAverageType> expenceAverageTypes = control.GetExpenceAverageTypes();
            List<string> expenceAverageTypeNames = new List<string>();
            foreach (ExpenseAverageType item in expenceAverageTypes)
            {
                expenceAverageTypeNames.Add(item.ExpenceAverageTypeName);
            }
            expenceAverageTypeBox.Items.AddRange(expenceAverageTypeNames.ToArray());
            ExpenseAverageType expenceAverageType = control.GetCurrentExpenceAverageType();
            if (expenceAverageType != null)
            {
                expenceAverageTypeBox.Text = expenceAverageType.ExpenceAverageTypeName;
                ExpenceAverageDateTimePicker.Value = expenceAverageType.StartDate;
            }
        }
    }
}
