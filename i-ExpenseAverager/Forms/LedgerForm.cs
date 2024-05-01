using i_ExpenseAverager.Models;
using i_ExpenseAverager.Repositories;

namespace i_ExpenseAverager.Forms
{
    public partial class LedgerForm : Form
    {
        ExpenseAverage2XDB XDB;

        ExpenseAverage2 selectedExpence;
        public LedgerForm(ExpenseAverage2XDB XDB)
        {
            InitializeComponent();
            this.XDB = XDB;
            this.recordSubmitDateTimePicker.MinDate = this.XDB.StartDate;
            this.recordSubmitDateTimePicker.MaxDate = DateTime.Today;
            selectedExpence = null;
            RefreshRecordSubmitDisplay();
            RefreshRecordsDisplay();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            XDB.SubmitChanges();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string type;
            if (string.IsNullOrWhiteSpace(recordSubmitExpenceTypeComboBox.Text))
            {
                MessageBox.Show("The expence type must be a type. i.e. 'Fuel'");
                return;
            }
            type = recordSubmitExpenceTypeComboBox.Text;
            string location;
            if (string.IsNullOrWhiteSpace(recordSubmitExpenceLocationComboBox.Text))
            {
                MessageBox.Show("The expence location must be a retail name. i.e. 'Foodmart'");
                return;
            }
            location = recordSubmitExpenceLocationComboBox.Text;
            string occasion;
            if (string.IsNullOrWhiteSpace(recordSubmitOccasionComboBox.Text))
            {
                MessageBox.Show("The expence occasion must be an occasion. i.e. 'Birthday' or 'None'");
                return;
            }
            occasion = recordSubmitOccasionComboBox.Text;
            double amount;
            if (!double.TryParse(recordSubmitAmountBox.Text, out amount))
            {
                MessageBox.Show("The amount must be a decimal number. i.e. '7.50'");
                return;
            }
            if (amount <= 0.00)
            {
                MessageBox.Show("The amount must be a decimal number greater than 0. i.e. '7.50'");
                return;
            }
            amount = double.Parse(amount.ToString("0.00"));
            DateTime date;
            if (!DateTime.TryParse(recordSubmitDateTimePicker.Text, out date))
            {
                MessageBox.Show("The date must be a correct date. i.e. 7/28/2017");
                return;
            }
            string note = recordSubmitNoteBox.Text;
            if (string.IsNullOrWhiteSpace(note))
            {
                note = "";
            }
            XDB.SaveExpenseAverageType(type);
            XDB.SaveExpenseLocation(location);
            XDB.SaveExpenseOccasion(occasion);
            if (selectedExpence == null)
            {
                XDB.SaveExpenseAverage(type, location, occasion, date, amount, note);
            }
            else
            {
                selectedExpence.ExpenseAverageTypeID = XDB.GetExpenseAverageType(type).ExpenseTagID;
                selectedExpence.ExpenseLocationID = XDB.GetExpenseLocation(location).ExpenseTagID;
                selectedExpence.ExpenseOccasionID = XDB.GetExpenseOccasion(occasion).ExpenseTagID;
                selectedExpence.ExpenseAverageAmount = amount;
                selectedExpence.Date = date;
                selectedExpence.Note = note;
                selectedExpence = null;
                this.addButton.Text = "Add";
            }
            RefreshRecordSubmitDisplay();
            RefreshRecordsDisplay();
        }



        private void RefreshRecordSubmitDisplay()
        {
            recordSubmitAmountBox.Text = "";
            //recordSubmitDateTimePicker.Text = DateTime.Now.ToShortDateString();
            recordSubmitNoteBox.Text = "";
            this.addButton.Text = "Add";

            recordSubmitExpenceTypeComboBox.Items.Clear();
            foreach (ExpenseTag item in XDB.expenseTypes.ToList())
            {
                recordSubmitExpenceTypeComboBox.Items.Add(item.ExpenseTagName);
            }

            recordSubmitExpenceLocationComboBox.Items.Clear();
            foreach (ExpenseTag item in XDB.expenseLocations.ToList())
            {
                recordSubmitExpenceLocationComboBox.Items.Add(item.ExpenseTagName);
            }

            recordSubmitOccasionComboBox.Items.Clear();
            foreach (ExpenseTag item in XDB.expenseOccasions.ToList())
            {
                recordSubmitOccasionComboBox.Items.Add(item.ExpenseTagName);
            }
        }

        private void RefreshRecordsDisplay()
        {
            expenceAverageRecordDataGridView.Rows.Clear();
            DataGridViewRow gridRow;
            List<ExpenseAverage2> records = XDB.expenseAverages.ToListByDate();

            int daysFor1Month = 31;
            int daysFor3Month = 92;
            int daysFor6Month = 183;
            int daysFor12Month = 367;

            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            foreach (ExpenseAverage2 item in records)
            {

                gridRow = (DataGridViewRow)expenceAverageRecordDataGridView.Rows[0].Clone();
                gridRow.Height = 15;
                gridRow.Cells[0].Value = item;
                gridRow.Cells[RecordNumberColumn.Index].Value = item.ExpenseAverageID;
                gridRow.Cells[DayColumn.Index].Value = item.Date.DayOfWeek;
                rows.Add(gridRow);
                //expenceAverageRecordDataGridView.Rows.Add(gridRow);
                gridRow.Cells[DateColumn.Index].Value = item.Date.ToShortDateString();
                if (item.ExpenseAverageAmount > 0)
                {
                    gridRow.Cells[AmountColumn.Index].Value = "$" + item.ExpenseAverageAmount;
                }
                gridRow.Cells[ExpenceTypeColumn.Index].Value = XDB.GetExpenseAverageType(item.ExpenseAverageTypeID).ExpenseTagName;
                gridRow.Cells[LocationColumn.Index].Value = XDB.GetExpenseLocation(item.ExpenseLocationID).ExpenseTagName;
                gridRow.Cells[OccasionColumn.Index].Value = XDB.GetExpenseOccasion(item.ExpenseOccasionID).ExpenseTagName;

                gridRow.Cells[NoteColumn.Index].Value = item.Note;
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

                if (item.Date == DateTime.Parse(DateTime.Now.ToShortDateString()).AddDays(-(daysFor1Month)))
                {
                    gridRow.Cells[DateColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[NoteColumn.Index].Style.BackColor = Color.LightGray;
                    if (gridRow.Cells[NoteColumn.Index].Value.ToString() == "")
                    {
                        gridRow.Cells[NoteColumn.Index].Value = "1 Month";
                    }
                }
                else if (item.Date == DateTime.Parse(DateTime.Now.ToShortDateString()).AddDays(-(daysFor3Month)))
                {
                    gridRow.Cells[DateColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[NoteColumn.Index].Style.BackColor = Color.LightGray;
                    if (gridRow.Cells[NoteColumn.Index].Value.ToString() == "")
                    {
                        gridRow.Cells[NoteColumn.Index].Value = "3 Months";
                    }
                }
                else if (item.Date == DateTime.Parse(DateTime.Now.ToShortDateString()).AddDays(-(daysFor6Month)))
                {
                    gridRow.Cells[DateColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[NoteColumn.Index].Style.BackColor = Color.LightGray;
                    if (gridRow.Cells[NoteColumn.Index].Value.ToString() == "")
                    {
                        gridRow.Cells[NoteColumn.Index].Value = "6 Months";
                    }
                }
                else if (item.Date == DateTime.Parse(DateTime.Now.ToShortDateString()).AddDays(-(daysFor12Month)))
                {
                    gridRow.Cells[DateColumn.Index].Style.BackColor = Color.LightGray;
                    gridRow.Cells[NoteColumn.Index].Style.BackColor = Color.LightGray;
                    if (gridRow.Cells[NoteColumn.Index].Value.ToString() == "")
                    {
                        gridRow.Cells[NoteColumn.Index].Value = "12 Months";
                    }
                }
                else
                {
                    gridRow.Cells[DateColumn.Index].Style.BackColor = Color.White;
                    gridRow.Cells[NoteColumn.Index].Style.BackColor = Color.White;
                }


            }
            expenceAverageRecordDataGridView.Rows.AddRange(rows.ToArray());
            expenceAverageRecordDataGridView.FirstDisplayedScrollingRowIndex = expenceAverageRecordDataGridView.RowCount - 1;
            recordSubmitAmountBox.Text = "0";
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            selectedExpence = (ExpenseAverage2)expenceAverageRecordDataGridView.SelectedRows[0].Cells[0].Value;
            if (selectedExpence == null)
            {
                return;
            }
            recordSubmitAmountBox.Text = selectedExpence.ExpenseAverageAmount.ToString("0.00");
            recordSubmitExpenceTypeComboBox.Text = XDB.GetExpenseAverageType(selectedExpence.ExpenseAverageTypeID).ExpenseTagName;
            recordSubmitExpenceLocationComboBox.Text = XDB.GetExpenseLocation(selectedExpence.ExpenseLocationID).ExpenseTagName;
            recordSubmitOccasionComboBox.Text = XDB.GetExpenseOccasion(selectedExpence.ExpenseOccasionID).ExpenseTagName;
            recordSubmitDateTimePicker.Text = selectedExpence.Date.ToShortDateString();
            recordSubmitNoteBox.Text = selectedExpence.Note;
            this.addButton.Text = "Change";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            selectedExpence = (ExpenseAverage2)expenceAverageRecordDataGridView.SelectedRows[0].Cells[0].Value;
            if (selectedExpence == null)
            {
                return;
            }
            XDB.DeleteExpenseAverage(selectedExpence);
            selectedExpence = null;
            RefreshRecordSubmitDisplay();
            RefreshRecordsDisplay();
        }
    }
}
