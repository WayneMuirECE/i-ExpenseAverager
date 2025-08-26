namespace i_ExpenseAverager.Forms
{
    partial class LedgerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            recordSubmitGroupBox = new GroupBox();
            deleteButton = new Button();
            modifyButton = new Button();
            recordSubmitDateTimePicker = new DateTimePicker();
            recordSubmitOccasionComboBox = new ComboBox();
            label15 = new Label();
            label2 = new Label();
            label8 = new Label();
            recordSubmitExpenseTypeComboBox = new ComboBox();
            addButton = new Button();
            recordSubmitExpenseLocationComboBox = new ComboBox();
            label7 = new Label();
            recordSubmitNoteBox = new TextBox();
            label1 = new Label();
            label14 = new Label();
            recordSubmitAmountBox = new TextBox();
            expenceAverageRecordDataGridView = new DataGridView();
            ObjectColumn = new DataGridViewTextBoxColumn();
            RecordNumberColumn = new DataGridViewTextBoxColumn();
            DayColumn = new DataGridViewTextBoxColumn();
            DateColumn = new DataGridViewTextBoxColumn();
            AmountColumn = new DataGridViewTextBoxColumn();
            ExpenseTypeColumn = new DataGridViewTextBoxColumn();
            LocationColumn = new DataGridViewTextBoxColumn();
            OccasionColumn = new DataGridViewTextBoxColumn();
            NoteColumn = new DataGridViewTextBoxColumn();
            recordSubmitGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)expenceAverageRecordDataGridView).BeginInit();
            SuspendLayout();
            // 
            // recordSubmitGroupBox
            // 
            recordSubmitGroupBox.Controls.Add(deleteButton);
            recordSubmitGroupBox.Controls.Add(modifyButton);
            recordSubmitGroupBox.Controls.Add(recordSubmitDateTimePicker);
            recordSubmitGroupBox.Controls.Add(recordSubmitOccasionComboBox);
            recordSubmitGroupBox.Controls.Add(label15);
            recordSubmitGroupBox.Controls.Add(label2);
            recordSubmitGroupBox.Controls.Add(label8);
            recordSubmitGroupBox.Controls.Add(recordSubmitExpenseTypeComboBox);
            recordSubmitGroupBox.Controls.Add(addButton);
            recordSubmitGroupBox.Controls.Add(recordSubmitExpenseLocationComboBox);
            recordSubmitGroupBox.Controls.Add(label7);
            recordSubmitGroupBox.Controls.Add(recordSubmitNoteBox);
            recordSubmitGroupBox.Controls.Add(label1);
            recordSubmitGroupBox.Controls.Add(label14);
            recordSubmitGroupBox.Controls.Add(recordSubmitAmountBox);
            recordSubmitGroupBox.Location = new Point(13, 12);
            recordSubmitGroupBox.Margin = new Padding(4, 3, 4, 3);
            recordSubmitGroupBox.Name = "recordSubmitGroupBox";
            recordSubmitGroupBox.Padding = new Padding(4, 3, 4, 3);
            recordSubmitGroupBox.Size = new Size(959, 87);
            recordSubmitGroupBox.TabIndex = 35;
            recordSubmitGroupBox.TabStop = false;
            recordSubmitGroupBox.Text = "Record Expense";
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(859, 53);
            deleteButton.Margin = new Padding(4, 3, 4, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(88, 27);
            deleteButton.TabIndex = 36;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // modifyButton
            // 
            modifyButton.Location = new Point(859, 20);
            modifyButton.Margin = new Padding(4, 3, 4, 3);
            modifyButton.Name = "modifyButton";
            modifyButton.Size = new Size(88, 27);
            modifyButton.TabIndex = 35;
            modifyButton.Text = "Edit";
            modifyButton.UseVisualStyleBackColor = true;
            modifyButton.Click += modifyButton_Click;
            // 
            // recordSubmitDateTimePicker
            // 
            recordSubmitDateTimePicker.Format = DateTimePickerFormat.Short;
            recordSubmitDateTimePicker.Location = new Point(98, 22);
            recordSubmitDateTimePicker.Margin = new Padding(4, 3, 4, 3);
            recordSubmitDateTimePicker.Name = "recordSubmitDateTimePicker";
            recordSubmitDateTimePicker.Size = new Size(116, 23);
            recordSubmitDateTimePicker.TabIndex = 29;
            // 
            // recordSubmitOccasionComboBox
            // 
            recordSubmitOccasionComboBox.FormattingEnabled = true;
            recordSubmitOccasionComboBox.Location = new Point(588, 22);
            recordSubmitOccasionComboBox.Margin = new Padding(4, 3, 4, 3);
            recordSubmitOccasionComboBox.Name = "recordSubmitOccasionComboBox";
            recordSubmitOccasionComboBox.Size = new Size(168, 23);
            recordSubmitOccasionComboBox.TabIndex = 34;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(8, 25);
            label15.Margin = new Padding(4, 0, 0, 0);
            label15.Name = "label15";
            label15.Size = new Size(83, 15);
            label15.TabIndex = 2;
            label15.Text = "For the day of:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(494, 25);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 33;
            label2.Text = "Occasion";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(223, 57);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 32;
            label8.Text = "Location";
            // 
            // recordSubmitExpenseTypeComboBox
            // 
            recordSubmitExpenseTypeComboBox.FormattingEnabled = true;
            recordSubmitExpenseTypeComboBox.Location = new Point(317, 22);
            recordSubmitExpenseTypeComboBox.Margin = new Padding(4, 3, 4, 3);
            recordSubmitExpenseTypeComboBox.Name = "recordSubmitExpenseTypeComboBox";
            recordSubmitExpenseTypeComboBox.Size = new Size(168, 23);
            recordSubmitExpenseTypeComboBox.TabIndex = 29;
            // 
            // addButton
            // 
            addButton.Location = new Point(764, 20);
            addButton.Margin = new Padding(4, 3, 4, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(88, 27);
            addButton.TabIndex = 4;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // recordSubmitExpenseLocationComboBox
            // 
            recordSubmitExpenseLocationComboBox.FormattingEnabled = true;
            recordSubmitExpenseLocationComboBox.Location = new Point(317, 53);
            recordSubmitExpenseLocationComboBox.Margin = new Padding(4, 3, 4, 3);
            recordSubmitExpenseLocationComboBox.Name = "recordSubmitExpenseLocationComboBox";
            recordSubmitExpenseLocationComboBox.Size = new Size(168, 23);
            recordSubmitExpenseLocationComboBox.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(494, 57);
            label7.Margin = new Padding(4, 0, 0, 0);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 6;
            label7.Text = "Note:";
            // 
            // recordSubmitNoteBox
            // 
            recordSubmitNoteBox.Location = new Point(547, 53);
            recordSubmitNoteBox.Margin = new Padding(4, 3, 4, 3);
            recordSubmitNoteBox.Name = "recordSubmitNoteBox";
            recordSubmitNoteBox.Size = new Size(209, 23);
            recordSubmitNoteBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(223, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 28;
            label1.Text = "Expense Type";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(8, 57);
            label14.Margin = new Padding(4, 0, 0, 0);
            label14.Name = "label14";
            label14.Size = new Size(54, 15);
            label14.TabIndex = 1;
            label14.Text = "Amount:";
            // 
            // recordSubmitAmountBox
            // 
            recordSubmitAmountBox.Location = new Point(98, 53);
            recordSubmitAmountBox.Margin = new Padding(0, 3, 4, 3);
            recordSubmitAmountBox.Name = "recordSubmitAmountBox";
            recordSubmitAmountBox.Size = new Size(81, 23);
            recordSubmitAmountBox.TabIndex = 0;
            // 
            // expenceAverageRecordDataGridView
            // 
            expenceAverageRecordDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            expenceAverageRecordDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            expenceAverageRecordDataGridView.Columns.AddRange(new DataGridViewColumn[] { ObjectColumn, RecordNumberColumn, DayColumn, DateColumn, AmountColumn, ExpenseTypeColumn, LocationColumn, OccasionColumn, NoteColumn });
            expenceAverageRecordDataGridView.Location = new Point(13, 105);
            expenceAverageRecordDataGridView.Margin = new Padding(4, 3, 4, 3);
            expenceAverageRecordDataGridView.Name = "expenceAverageRecordDataGridView";
            expenceAverageRecordDataGridView.ReadOnly = true;
            expenceAverageRecordDataGridView.RowTemplate.Height = 17;
            expenceAverageRecordDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            expenceAverageRecordDataGridView.Size = new Size(959, 593);
            expenceAverageRecordDataGridView.TabIndex = 34;
            // 
            // ObjectColumn
            // 
            ObjectColumn.HeaderText = "Object";
            ObjectColumn.Name = "ObjectColumn";
            ObjectColumn.ReadOnly = true;
            ObjectColumn.Width = 5;
            // 
            // RecordNumberColumn
            // 
            RecordNumberColumn.HeaderText = "#";
            RecordNumberColumn.Name = "RecordNumberColumn";
            RecordNumberColumn.ReadOnly = true;
            RecordNumberColumn.Width = 50;
            // 
            // DayColumn
            // 
            DayColumn.HeaderText = "Day";
            DayColumn.Name = "DayColumn";
            DayColumn.ReadOnly = true;
            DayColumn.Width = 80;
            // 
            // DateColumn
            // 
            DateColumn.HeaderText = "Date";
            DateColumn.Name = "DateColumn";
            DateColumn.ReadOnly = true;
            DateColumn.Width = 80;
            // 
            // AmountColumn
            // 
            AmountColumn.HeaderText = "Amount";
            AmountColumn.Name = "AmountColumn";
            AmountColumn.ReadOnly = true;
            AmountColumn.Width = 60;
            // 
            // ExpenseTypeColumn
            // 
            ExpenseTypeColumn.HeaderText = "Expense Type";
            ExpenseTypeColumn.Name = "ExpenseTypeColumn";
            ExpenseTypeColumn.ReadOnly = true;
            ExpenseTypeColumn.Width = 140;
            // 
            // LocationColumn
            // 
            LocationColumn.HeaderText = "Location";
            LocationColumn.Name = "LocationColumn";
            LocationColumn.ReadOnly = true;
            LocationColumn.Width = 140;
            // 
            // OccasionColumn
            // 
            OccasionColumn.HeaderText = "Occasion";
            OccasionColumn.Name = "OccasionColumn";
            OccasionColumn.ReadOnly = true;
            OccasionColumn.Width = 140;
            // 
            // NoteColumn
            // 
            NoteColumn.HeaderText = "Note";
            NoteColumn.Name = "NoteColumn";
            NoteColumn.ReadOnly = true;
            NoteColumn.Width = 175;
            // 
            // LedgerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 714);
            Controls.Add(recordSubmitGroupBox);
            Controls.Add(expenceAverageRecordDataGridView);
            Name = "LedgerForm";
            Text = "Ledger";
            recordSubmitGroupBox.ResumeLayout(false);
            recordSubmitGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)expenceAverageRecordDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox recordSubmitGroupBox;
        private Button deleteButton;
        private Button modifyButton;
        private DateTimePicker recordSubmitDateTimePicker;
        private ComboBox recordSubmitOccasionComboBox;
        private Label label15;
        private Label label2;
        private Label label8;
        private ComboBox recordSubmitExpenseTypeComboBox;
        private Button addButton;
        private ComboBox recordSubmitExpenseLocationComboBox;
        private Label label7;
        private TextBox recordSubmitNoteBox;
        private Label label1;
        private Label label14;
        private TextBox recordSubmitAmountBox;
        private DataGridView expenceAverageRecordDataGridView;
        private DataGridViewTextBoxColumn ObjectColumn;
        private DataGridViewTextBoxColumn RecordNumberColumn;
        private DataGridViewTextBoxColumn DayColumn;
        private DataGridViewTextBoxColumn DateColumn;
        private DataGridViewTextBoxColumn AmountColumn;
        private DataGridViewTextBoxColumn ExpenseTypeColumn;
        private DataGridViewTextBoxColumn LocationColumn;
        private DataGridViewTextBoxColumn OccasionColumn;
        private DataGridViewTextBoxColumn NoteColumn;
    }
}