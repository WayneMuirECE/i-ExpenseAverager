using i_ExpenseAverager.Models;
using i_ExpenseAverager.Repositories;

namespace i_ExpenseAverager.Forms
{
    public partial class LedgerForm : Form
    {
        private ExpenseAverage2XDB _XDB;

        private ExpenseAverage2 _SelectedExpence;
        public LedgerForm(ExpenseAverage2XDB XDB)
        {
            InitializeComponent();
            _XDB = XDB;
            recordSubmitDateTimePicker.MinDate = _XDB.StartDate;
            recordSubmitDateTimePicker.MaxDate = DateTime.Today;
            _SelectedExpence = null;
            RefreshRecordSubmitDisplay();
            RefreshRecordsDisplay();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _XDB.SubmitChanges();
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

            _XDB.SaveExpenseAverageType(type);
            _XDB.SaveExpenseLocation(location);
            _XDB.SaveExpenseOccasion(occasion);

            if (_SelectedExpence == null)
            {
                _XDB.SaveExpenseAverage(type, location, occasion, date, amount, note);
            }
            else
            {
                _SelectedExpence.ExpenseAverageTypeID = _XDB.GetExpenseAverageType(type).ExpenseTagID;
                _SelectedExpence.ExpenseLocationID = _XDB.GetExpenseLocation(location).ExpenseTagID;
                _SelectedExpence.ExpenseOccasionID = _XDB.GetExpenseOccasion(occasion).ExpenseTagID;
                _SelectedExpence.ExpenseAverageAmount = amount;
                _SelectedExpence.Date = date;
                _SelectedExpence.Note = note;
                _SelectedExpence = null;
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
            foreach (ExpenseTag item in _XDB.ExpenseTypes.ToList())
            {
                recordSubmitExpenceTypeComboBox.Items.Add(item.ExpenseTagName);
            }

            recordSubmitExpenceLocationComboBox.Items.Clear();
            foreach (ExpenseTag item in _XDB.ExpenseLocations.ToList())
            {
                recordSubmitExpenceLocationComboBox.Items.Add(item.ExpenseTagName);
            }

            recordSubmitOccasionComboBox.Items.Clear();
            foreach (ExpenseTag item in _XDB.ExpenseOccasions.ToList())
            {
                recordSubmitOccasionComboBox.Items.Add(item.ExpenseTagName);
            }
        }

        private void RefreshRecordsDisplay()
        {
            expenceAverageRecordDataGridView.Rows.Clear();
            DataGridViewRow gridRow;
            List<ExpenseAverage2> records = _XDB.ExpenseAverages.ToListByDate();

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
                gridRow.Cells[ExpenceTypeColumn.Index].Value = _XDB.GetExpenseAverageType(item.ExpenseAverageTypeID).ExpenseTagName;
                gridRow.Cells[LocationColumn.Index].Value = _XDB.GetExpenseLocation(item.ExpenseLocationID).ExpenseTagName;
                gridRow.Cells[OccasionColumn.Index].Value = _XDB.GetExpenseOccasion(item.ExpenseOccasionID).ExpenseTagName;

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
            _SelectedExpence = (ExpenseAverage2)expenceAverageRecordDataGridView.SelectedRows[0].Cells[0].Value;

            if (_SelectedExpence == null)
            {
                return;
            }

            recordSubmitAmountBox.Text = _SelectedExpence.ExpenseAverageAmount.ToString("0.00");
            recordSubmitExpenceTypeComboBox.Text = _XDB.GetExpenseAverageType(_SelectedExpence.ExpenseAverageTypeID).ExpenseTagName;
            recordSubmitExpenceLocationComboBox.Text = _XDB.GetExpenseLocation(_SelectedExpence.ExpenseLocationID).ExpenseTagName;
            recordSubmitOccasionComboBox.Text = _XDB.GetExpenseOccasion(_SelectedExpence.ExpenseOccasionID).ExpenseTagName;
            recordSubmitDateTimePicker.Text = _SelectedExpence.Date.ToShortDateString();
            recordSubmitNoteBox.Text = _SelectedExpence.Note;
            addButton.Text = "Change";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            _SelectedExpence = (ExpenseAverage2)expenceAverageRecordDataGridView.SelectedRows[0].Cells[0].Value;

            if (_SelectedExpence == null)
            {
                return;
            }

            _XDB.DeleteExpenseAverage(_SelectedExpence);
            _SelectedExpence = null;
            RefreshRecordSubmitDisplay();
            RefreshRecordsDisplay();
        }
    }
}
