using i_ExpenseAverager.Interfaces;
using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.Forms
{
    public partial class LedgerForm : Form
    {
        private IExpenseAverageXDB _xDB;
        private ExpenseAverage _selectedExpence;

        public LedgerForm(IExpenseAverageXDB XDB)
        {
            InitializeComponent();
            _xDB = XDB;
            recordSubmitDateTimePicker.MinDate = _xDB.StartDate;
            recordSubmitDateTimePicker.MaxDate = DateTime.Today;
            _selectedExpence = null;
            RefreshRecordSubmitDisplay();
            RefreshRecordsDisplay();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _xDB.SubmitChanges();
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

            _xDB.SaveExpenseAverageType(type);
            _xDB.SaveExpenseLocation(location);
            _xDB.SaveExpenseOccasion(occasion);

            if (_selectedExpence == null)
            {
                _xDB.SaveExpenseAverage(type, location, occasion, date, amount, note);
            }
            else
            {
                _selectedExpence.ExpenseAverageTypeID = _xDB.GetExpenseAverageType(type).ExpenseTagID;
                _selectedExpence.ExpenseLocationID = _xDB.GetExpenseLocation(location).ExpenseTagID;
                _selectedExpence.ExpenseOccasionID = _xDB.GetExpenseOccasion(occasion).ExpenseTagID;
                _selectedExpence.ExpenseAverageAmount = amount;
                _selectedExpence.Date = date;
                _selectedExpence.Note = note;
                _selectedExpence = null;
                addButton.Text = "Add";
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
            foreach (ExpenseTag item in _xDB.ExpenseTypes.ToList())
            {
                recordSubmitExpenceTypeComboBox.Items.Add(item.ExpenseTagName);
            }

            recordSubmitExpenceLocationComboBox.Items.Clear();
            foreach (ExpenseTag item in _xDB.ExpenseLocations.ToList())
            {
                recordSubmitExpenceLocationComboBox.Items.Add(item.ExpenseTagName);
            }

            recordSubmitOccasionComboBox.Items.Clear();
            foreach (ExpenseTag item in _xDB.ExpenseOccasions.ToList())
            {
                recordSubmitOccasionComboBox.Items.Add(item.ExpenseTagName);
            }
        }

        private void RefreshRecordsDisplay()
        {
            expenceAverageRecordDataGridView.Rows.Clear();
            DataGridViewRow gridRow;
            List<ExpenseAverage> records = _xDB.ExpenseAverages.ToListByDate();

            int daysFor1Month = 31;
            int daysFor3Month = 92;
            int daysFor6Month = 183;
            int daysFor12Month = 367;

            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            foreach (ExpenseAverage item in records)
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
                gridRow.Cells[ExpenceTypeColumn.Index].Value = _xDB.GetExpenseAverageType(item.ExpenseAverageTypeID).ExpenseTagName;
                gridRow.Cells[LocationColumn.Index].Value = _xDB.GetExpenseLocation(item.ExpenseLocationID).ExpenseTagName;
                gridRow.Cells[OccasionColumn.Index].Value = _xDB.GetExpenseOccasion(item.ExpenseOccasionID).ExpenseTagName;

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
            _selectedExpence = (ExpenseAverage)expenceAverageRecordDataGridView.SelectedRows[0].Cells[0].Value;

            if (_selectedExpence == null)
            {
                return;
            }

            recordSubmitAmountBox.Text = _selectedExpence.ExpenseAverageAmount.ToString("0.00");
            recordSubmitExpenceTypeComboBox.Text = _xDB.GetExpenseAverageType(_selectedExpence.ExpenseAverageTypeID).ExpenseTagName;
            recordSubmitExpenceLocationComboBox.Text = _xDB.GetExpenseLocation(_selectedExpence.ExpenseLocationID).ExpenseTagName;
            recordSubmitOccasionComboBox.Text = _xDB.GetExpenseOccasion(_selectedExpence.ExpenseOccasionID).ExpenseTagName;
            recordSubmitDateTimePicker.Text = _selectedExpence.Date.ToShortDateString();
            recordSubmitNoteBox.Text = _selectedExpence.Note;
            addButton.Text = "Change";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            _selectedExpence = (ExpenseAverage)expenceAverageRecordDataGridView.SelectedRows[0].Cells[0].Value;

            if (_selectedExpence == null)
            {
                return;
            }

            _xDB.DeleteExpenseAverage(_selectedExpence);
            _selectedExpence = null;
            RefreshRecordSubmitDisplay();
            RefreshRecordsDisplay();
        }
    }
}
