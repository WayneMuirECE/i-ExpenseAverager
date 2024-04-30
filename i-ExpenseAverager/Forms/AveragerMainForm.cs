using i_ExpenceAverager.Models;
using i_ExpenceAverager.Repositories;
using i_ExpenceAverager.ViewModelLibrary;

namespace i_ExpenceAverager.Forms
{
    public partial class AveragerMainForm : Form
    {
        private ExpenseAverage2XDB XDB;
        private ExpenseAverageViewXDB ViewXDB;

        public AveragerMainForm()
        {
            InitializeComponent();

            XDB = new ExpenseAverage2XDB();
            ViewXDB = new ExpenseAverageViewXDB(XDB);
        }

        private void RefreshRecordsDisplay(ExpenseAverageCategory category)
        {
            expenceAverageRecordDataGridView.Rows.Clear();
            DataGridViewRow gridRow;

            ChainClass year = ViewXDB.RefreshDisplay(category);

            yearAvgBox.Text = category.YearAvg;
            sixMonthAvgBox.Text = category.SixMonthAvg;
            threeMonthAvgBox.Text = category.ThreeMonthAvg;
            monthAvgBox.Text = category.MonthAvg;
            dailyAvgBox.Text = category.DailyAvg;
            totalAvgBox.Text = category.TotalAvg;

            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            foreach (ExpenseAverageDay item in year.ChainHead.GetNodes())
            {
                gridRow = (DataGridViewRow)expenceAverageRecordDataGridView.Rows[0].Clone();
                gridRow.Height = 15;
                gridRow.Cells[DayColumn.Index].Value = item.Date.DayOfWeek;
                rows.Add(gridRow);
                gridRow.Cells[DateColumn.Index].Value = item.Date.ToShortDateString();

                if (item.DaysTotal > 0)
                {
                    gridRow.Cells[AmountColumn.Index].Value = "$" + item.DaysTotal;
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
                foreach (ExpenseAverage2 expence in item.DaysExpences)
                {
                    types += XDB.expenceTypes.ItemById(expence.ExpenceAverageTypeID).ExpenseTagName + ", ";
                }

                gridRow.Cells[ExpenceTypeColumn.Index].Value = types;

                types = "";

                foreach (ExpenseAverage2 expence in item.DaysExpences)
                {
                    types += XDB.expenceLocations.ItemById(expence.ExpenceLocationID).ExpenseTagName + ", ";
                }

                gridRow.Cells[LocationColumn.Index].Value = types;

                types = "";

                foreach (ExpenseAverage2 expence in item.DaysExpences)
                {
                    if (!string.IsNullOrWhiteSpace(expence.Note))
                    {
                        types += expence.Note + ", ";
                    }
                }

                gridRow.Cells[NoteColumn.Index].Value = types;

                if (item.Date == DateTime.Today.AddDays(-(ViewXDB.daysFor1Month - 1)))
                {
                    gridRow.Cells[AmountColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[NoteColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[ExpenceTypeColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[LocationColumn.Index].Style.BackColor = Color.LightGray;

                    if (gridRow.Cells[NoteColumn.Index].Value.ToString() == "")
                    {
                        gridRow.Cells[NoteColumn.Index].Value = "1 Month";
                    }
                }
                else if (item.Date == DateTime.Parse(DateTime.Now.ToShortDateString()).AddDays(-(ViewXDB.daysFor3Month - 1)))
                {
                    gridRow.Cells[AmountColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[NoteColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[ExpenceTypeColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[LocationColumn.Index].Style.BackColor = Color.LightGray;

                    if (gridRow.Cells[NoteColumn.Index].Value.ToString() == "")
                    {
                        gridRow.Cells[NoteColumn.Index].Value = "3 Months";
                    }
                }
                else if (item.Date == DateTime.Parse(DateTime.Now.ToShortDateString()).AddDays(-(ViewXDB.daysFor6Month - 1)))
                {
                    gridRow.Cells[AmountColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[NoteColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[ExpenceTypeColumn.Index].Style.BackColor = Color.LightGray;
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
                    gridRow.Cells[ExpenceTypeColumn.Index].Style.BackColor = Color.White;
                    gridRow.Cells[LocationColumn.Index].Style.BackColor = Color.White;
                }
            }

            expenceAverageRecordDataGridView.Rows.AddRange(rows.ToArray());
            expenceAverageRecordDataGridView.FirstDisplayedScrollingRowIndex = expenceAverageRecordDataGridView.RowCount - 1;
            RefreshCategories();
        }

        private void RefreshCategories()
        {
            int selectedIndex = categoriesComboBox.SelectedIndex;
            categoriesComboBox.Items.Clear();

            foreach (ExpenseAverageCategory item in ViewXDB.categoryList)
            {
                categoriesComboBox.Items.Add(item);
            }

            categoriesComboBox.SelectedIndex = selectedIndex;
            categoriesComboBox.Refresh();

            expenceTypeListBox.Items.Clear();

            foreach (ExpenseTag item in XDB.expenceTypes.ToList())
            {
                expenceTypeListBox.Items.Add(item);
            }

            listBox1.Items.Clear();
            categoryNewTextBox.Text = "";
        }

        private void expenceSettingsButton_Click(object sender, EventArgs e)
        {
            LedgerForm form = new LedgerForm(XDB);
            form.ShowDialog();
            RefreshRecordsDisplay(ViewXDB.CategoryAll);
        }
    }
}
