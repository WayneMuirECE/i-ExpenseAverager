using i_ExpenseAverager.Interfaces;
using i_ExpenseAverager.Models;
using i_ExpenseAverager.Repositories;
using i_ExpenseAverager.ViewModelLibrary;

namespace i_ExpenseAverager.Forms
{
    public partial class AveragerMainForm : Form
    {
        private IExpenseAverageXDB _xDB;
        private ViewRepositoryModel _viewModel;

        public AveragerMainForm(IExpenseAverageXDB xDB)
        {
            InitializeComponent();

            _xDB = xDB;
            _viewModel = new ViewRepositoryModel(_xDB);
        }

        private void AveragerMainForm_Load(object sender, EventArgs e)
        {
            accountNameTextBox.Text = _xDB.AccountName;
            accountStartDateTimePicker.Text = _xDB.StartDate.ToShortDateString();

            foreach (CalendarAveragesGroup item in _viewModel.CategoryList)
            {
                typesComboBox.Items.Add(item);
            }

            typesComboBox.SelectedIndex = 0;
            RefreshRecordsDisplay(_viewModel.CategoryAll);
        }

        private void RefreshRecordsDisplay(CalendarAveragesGroup averageGroup)
        {
            expenseAverageRecordDataGridView.Rows.Clear();
            DataGridViewRow gridRow;

            ChainClass year = _viewModel.RefreshDisplay(averageGroup);

            yearAvgBox.Text = averageGroup.YearAvg;
            sixMonthAvgBox.Text = averageGroup.SixMonthAvg;
            threeMonthAvgBox.Text = averageGroup.ThreeMonthAvg;
            monthAvgBox.Text = averageGroup.MonthAvg;
            dailyAvgBox.Text = averageGroup.DailyAvg;
            totalAvgBox.Text = averageGroup.TotalAvg;

            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            foreach (ExpenseAverageDay item in year.ChainHead.GetNodes())
            {
                gridRow = (DataGridViewRow)expenseAverageRecordDataGridView.Rows[0].Clone();
                gridRow.Height = 15;
                gridRow.Cells[DayColumn.Index].Value = item.Date.DayOfWeek;
                rows.Add(gridRow);
                gridRow.Cells[DateColumn.Index].Value = item.Date.ToShortDateString();

                if (item.DaysTotal > 0)
                {
                    gridRow.Cells[AmountColumn.Index].Value = "$" + item.DaysTotal.ToString("0.00");
                }

                gridRow.Cells[NoteColumn.Index].Value = "";

                if (item.Date.DayOfWeek.ToString().Equals("Sunday"))
                {
                    gridRow.Cells[DayColumn.Index].Style.BackColor = Color.LightGray;
                }
                else if (item.Date.DayOfWeek.ToString().Equals("Saturday"))
                {
                    gridRow.Cells[DayColumn.Index].Style.BackColor = Color.LightGray;
                }
                else
                {
                    gridRow.Cells[DayColumn.Index].Style.BackColor = Color.White;
                }

                if (item.Date.Day == 1)
                {
                    gridRow.Cells[DateColumn.Index].Style.BackColor = Color.LightGray;
                }
                else
                {
                    gridRow.Cells[DateColumn.Index].Style.BackColor = Color.White;
                }

                string types = "";
                foreach (ExpenseAverage expense in item.DaysExpenses)
                {
                    types += _xDB.ExpenseTypes.ItemById(expense.ExpenseAverageTypeID).ExpenseTagName + ", ";
                }

                gridRow.Cells[ExpenseTypeColumn.Index].Value = types;

                types = "";

                foreach (ExpenseAverage expense in item.DaysExpenses)
                {
                    types += _xDB.ExpenseLocations.ItemById(expense.ExpenseLocationID).ExpenseTagName + ", ";
                }

                gridRow.Cells[LocationColumn.Index].Value = types;

                types = "";

                foreach (ExpenseAverage expense in item.DaysExpenses)
                {
                    if (!string.IsNullOrWhiteSpace(expense.Note))
                    {
                        types += expense.Note + ", ";
                    }
                }

                gridRow.Cells[NoteColumn.Index].Value = types;

                if (item.Date == DateTime.Today.AddDays(-(_viewModel.DaysFor1Month - 1)))
                {
                    gridRow.Cells[AmountColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[NoteColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[ExpenseTypeColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[LocationColumn.Index].Style.BackColor = Color.LightGray;

                    if (gridRow.Cells[NoteColumn.Index].Value.ToString() == "")
                    {
                        gridRow.Cells[NoteColumn.Index].Value = "1 Month";
                    }
                }
                else if (item.Date == DateTime.Parse(DateTime.Now.ToShortDateString()).AddDays(-(_viewModel.DaysFor3Month - 1)))
                {
                    gridRow.Cells[AmountColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[NoteColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[ExpenseTypeColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[LocationColumn.Index].Style.BackColor = Color.LightGray;

                    if (gridRow.Cells[NoteColumn.Index].Value.ToString() == "")
                    {
                        gridRow.Cells[NoteColumn.Index].Value = "3 Months";
                    }
                }
                else if (item.Date == DateTime.Parse(DateTime.Now.ToShortDateString()).AddDays(-(_viewModel.DaysFor6Month - 1)))
                {
                    gridRow.Cells[AmountColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[NoteColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[ExpenseTypeColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[LocationColumn.Index].Style.BackColor = Color.LightGray;

                    if (gridRow.Cells[NoteColumn.Index].Value.ToString() == "")
                    {
                        gridRow.Cells[NoteColumn.Index].Value = "6 Months";
                    }
                }
                else
                {
                    gridRow.Cells[AmountColumn.Index].Style.BackColor = Color.White;
                    gridRow.Cells[NoteColumn.Index].Style.BackColor = Color.White;
                    gridRow.Cells[ExpenseTypeColumn.Index].Style.BackColor = Color.White;
                    gridRow.Cells[LocationColumn.Index].Style.BackColor = Color.White;
                }
            }

            expenseAverageRecordDataGridView.Rows.AddRange(rows.ToArray());
            expenseAverageRecordDataGridView.FirstDisplayedScrollingRowIndex = expenseAverageRecordDataGridView.RowCount - 1;
            RefreshCategories();
            RefreshLocations();
        }

        private void RefreshCategories()
        {
            int selectedIndex = typesComboBox.SelectedIndex;
            typesComboBox.Items.Clear();

            foreach (CalendarAveragesGroup item in _viewModel.CategoryList)
            {
                typesComboBox.Items.Add(item);
            }

            typesComboBox.SelectedIndex = selectedIndex;
            typesComboBox.Refresh();
        }

        private void RefreshLocations()
        {
            int selectedIndex = locationsComboBox.SelectedIndex;
            locationsComboBox.Items.Clear();

            foreach (CalendarAveragesGroup item in _viewModel.LocationList)
            {
                locationsComboBox.Items.Add(item);
            }

            locationsComboBox.SelectedIndex = selectedIndex;
            locationsComboBox.Refresh();
        }

        private void expenseSettingsButton_Click(object sender, EventArgs e)
        {
            LedgerForm form = new LedgerForm(_xDB);
            form.ShowDialog();
            _viewModel.RefreshCategoriesFromDB();
            _viewModel.RefreshLocationsFromDB();
            RefreshRecordsDisplay(_viewModel.CategoryAll);
        }

        private void saveAccountNameButton_Click(object sender, EventArgs e)
        {
            _xDB.AccountName = accountNameTextBox.Text;
        }

        private void saveStartDateButton_Click(object sender, EventArgs e)
        {
            _xDB.StartDate = DateTime.Parse(accountStartDateTimePicker.Text);
            RefreshRecordsDisplay(_viewModel.CategoryAll);
        }

        private void viewTypeButton_Click(object sender, EventArgs e)
        {
            RefreshRecordsDisplay((CalendarAveragesGroup)typesComboBox.SelectedItem);
        }

        private void viewLocationButton_Click(object sender, EventArgs e)
        {
            RefreshRecordsDisplay((CalendarAveragesGroup)locationsComboBox.SelectedItem);
        }
    }
}
