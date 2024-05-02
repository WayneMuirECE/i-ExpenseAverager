using i_ExpenseAverager.Models;
using i_ExpenseAverager.Repositories;
using i_ExpenseAverager.ViewModelLibrary;

namespace i_ExpenseAverager.Forms
{
    public partial class AveragerMainForm : Form
    {
        private ExpenseAverage2XDB _XDB;
        private ExpenseAverageViewXDB _ViewXDB;

        public AveragerMainForm()
        {
            InitializeComponent();

            _XDB = new ExpenseAverage2XDB();
            _ViewXDB = new ExpenseAverageViewXDB(_XDB);
        }

        private void AveragerMainForm_Load(object sender, EventArgs e)
        {
            accountNameTextBox.Text = _XDB.AccountName;
            accountStartDateTimePicker.Text = _XDB.StartDate.ToShortDateString();

            foreach (ExpenseAverageCategory item in _ViewXDB.CategoryList)
            {
                categoriesComboBox.Items.Add(item);
            }

            categoriesComboBox.SelectedIndex = 0;
            RefreshRecordsDisplay(_ViewXDB.CategoryAll);
        }

        private void RefreshRecordsDisplay(ExpenseAverageCategory category)
        {
            expenseAverageRecordDataGridView.Rows.Clear();
            DataGridViewRow gridRow;

            ChainClass year = _ViewXDB.RefreshDisplay(category);

            yearAvgBox.Text = category.YearAvg;
            sixMonthAvgBox.Text = category.SixMonthAvg;
            threeMonthAvgBox.Text = category.ThreeMonthAvg;
            monthAvgBox.Text = category.MonthAvg;
            dailyAvgBox.Text = category.DailyAvg;
            totalAvgBox.Text = category.TotalAvg;

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
                foreach (ExpenseAverage2 expense in item.DaysExpenses)
                {
                    types += _XDB.ExpenseTypes.ItemById(expense.ExpenseAverageTypeID).ExpenseTagName + ", ";
                }

                gridRow.Cells[ExpenseTypeColumn.Index].Value = types;

                types = "";

                foreach (ExpenseAverage2 expense in item.DaysExpenses)
                {
                    types += _XDB.ExpenseLocations.ItemById(expense.ExpenseLocationID).ExpenseTagName + ", ";
                }

                gridRow.Cells[LocationColumn.Index].Value = types;

                types = "";

                foreach (ExpenseAverage2 expense in item.DaysExpenses)
                {
                    if (!string.IsNullOrWhiteSpace(expense.Note))
                    {
                        types += expense.Note + ", ";
                    }
                }

                gridRow.Cells[NoteColumn.Index].Value = types;

                if (item.Date == DateTime.Today.AddDays(-(_ViewXDB.daysFor1Month - 1)))
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
                else if (item.Date == DateTime.Parse(DateTime.Now.ToShortDateString()).AddDays(-(_ViewXDB.daysFor3Month - 1)))
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
                else if (item.Date == DateTime.Parse(DateTime.Now.ToShortDateString()).AddDays(-(_ViewXDB.daysFor6Month - 1)))
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
        }

        private void RefreshCategories()
        {
            int selectedIndex = categoriesComboBox.SelectedIndex;
            categoriesComboBox.Items.Clear();

            foreach (ExpenseAverageCategory item in _ViewXDB.CategoryList)
            {
                categoriesComboBox.Items.Add(item);
            }

            categoriesComboBox.SelectedIndex = selectedIndex;
            categoriesComboBox.Refresh();

            expenseTypeListBox.Items.Clear();

            foreach (ExpenseTag item in _XDB.ExpenseTypes.ToList())
            {
                expenseTypeListBox.Items.Add(item);
            }

            listBox1.Items.Clear();
        }

        private void expenseSettingsButton_Click(object sender, EventArgs e)
        {
            LedgerForm form = new LedgerForm(_XDB);
            form.ShowDialog();
            _ViewXDB.RefreshCategoriesFromDB();
            RefreshRecordsDisplay(_ViewXDB.CategoryAll);
        }

        private void saveAccountNameButton_Click(object sender, EventArgs e)
        {
            _XDB.AccountName = accountNameTextBox.Text;
        }

        private void saveStartDateButton_Click(object sender, EventArgs e)
        {
            _XDB.StartDate = DateTime.Parse(accountStartDateTimePicker.Text);
            RefreshRecordsDisplay(_ViewXDB.CategoryAll);
        }

        private void viewCategoryButton_Click(object sender, EventArgs e)
        {
            RefreshRecordsDisplay((ExpenseAverageCategory)categoriesComboBox.SelectedItem);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection collection = expenseTypeListBox.SelectedItems;
            ExpenseTag selected;

            foreach (object item in collection)
            {
                selected = (ExpenseTag)item;
                listBox1.Items.Add(selected);
            }

            expenseTypeListBox.Refresh();
            listBox1.Refresh();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
