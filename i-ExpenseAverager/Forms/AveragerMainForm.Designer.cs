namespace i_ExpenseAverager.Forms
{
    partial class AveragerMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            expenseAverageRecordDataGridView = new DataGridView();
            ObjectColumn = new DataGridViewTextBoxColumn();
            DayColumn = new DataGridViewTextBoxColumn();
            DateColumn = new DataGridViewTextBoxColumn();
            AmountColumn = new DataGridViewTextBoxColumn();
            ExpenseTypeColumn = new DataGridViewTextBoxColumn();
            LocationColumn = new DataGridViewTextBoxColumn();
            NoteColumn = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            label7 = new Label();
            totalAvgBox = new TextBox();
            label6 = new Label();
            yearAvgBox = new TextBox();
            label5 = new Label();
            sixMonthAvgBox = new TextBox();
            label4 = new Label();
            threeMonthAvgBox = new TextBox();
            label35 = new Label();
            monthAvgBox = new TextBox();
            label3 = new Label();
            dailyAvgBox = new TextBox();
            groupBox2 = new GroupBox();
            label2 = new Label();
            accountNameTextBox = new TextBox();
            expenseSettingsButton = new Button();
            saveAccountNameButton = new Button();
            accountStartDateTimePicker = new DateTimePicker();
            label1 = new Label();
            saveStartDateButton = new Button();
            groupBox3 = new GroupBox();
            expenseTypeListBox = new ListBox();
            clearButton = new Button();
            categoryNewTextBox = new TextBox();
            categoriesComboBox = new ComboBox();
            viewCategoryButton = new Button();
            saveNewCategoryButton = new Button();
            addButton = new Button();
            listBox1 = new ListBox();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)expenseAverageRecordDataGridView).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // expenseAverageRecordDataGridView
            // 
            expenseAverageRecordDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            expenseAverageRecordDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            expenseAverageRecordDataGridView.Columns.AddRange(new DataGridViewColumn[] { ObjectColumn, DayColumn, DateColumn, AmountColumn, ExpenseTypeColumn, LocationColumn, NoteColumn });
            expenseAverageRecordDataGridView.Location = new Point(13, 12);
            expenseAverageRecordDataGridView.Margin = new Padding(4, 3, 4, 3);
            expenseAverageRecordDataGridView.Name = "expenseAverageRecordDataGridView";
            expenseAverageRecordDataGridView.ReadOnly = true;
            expenseAverageRecordDataGridView.RowTemplate.Height = 17;
            expenseAverageRecordDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            expenseAverageRecordDataGridView.Size = new Size(728, 507);
            expenseAverageRecordDataGridView.TabIndex = 27;
            // 
            // ObjectColumn
            // 
            ObjectColumn.HeaderText = "Object";
            ObjectColumn.Name = "ObjectColumn";
            ObjectColumn.ReadOnly = true;
            ObjectColumn.Width = 5;
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
            AmountColumn.Width = 50;
            // 
            // ExpenseTypeColumn
            // 
            ExpenseTypeColumn.HeaderText = "expense Type";
            ExpenseTypeColumn.Name = "ExpenseTypeColumn";
            ExpenseTypeColumn.ReadOnly = true;
            ExpenseTypeColumn.Width = 155;
            // 
            // LocationColumn
            // 
            LocationColumn.HeaderText = "Location";
            LocationColumn.Name = "LocationColumn";
            LocationColumn.ReadOnly = true;
            LocationColumn.Width = 140;
            // 
            // NoteColumn
            // 
            NoteColumn.HeaderText = "Note";
            NoteColumn.Name = "NoteColumn";
            NoteColumn.ReadOnly = true;
            NoteColumn.Width = 155;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(totalAvgBox);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(yearAvgBox);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(sixMonthAvgBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(threeMonthAvgBox);
            groupBox1.Controls.Add(label35);
            groupBox1.Controls.Add(monthAvgBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dailyAvgBox);
            groupBox1.Location = new Point(748, 428);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(422, 91);
            groupBox1.TabIndex = 33;
            groupBox1.TabStop = false;
            groupBox1.Text = "Averages";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 18);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 18;
            label7.Text = "Total Avg.";
            // 
            // totalAvgBox
            // 
            totalAvgBox.Location = new Point(7, 37);
            totalAvgBox.Margin = new Padding(4, 3, 4, 3);
            totalAvgBox.Name = "totalAvgBox";
            totalAvgBox.ReadOnly = true;
            totalAvgBox.Size = new Size(75, 23);
            totalAvgBox.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(339, 18);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(29, 15);
            label6.TabIndex = 16;
            label6.Text = "Year";
            // 
            // yearAvgBox
            // 
            yearAvgBox.Location = new Point(338, 37);
            yearAvgBox.Margin = new Padding(4, 3, 4, 3);
            yearAvgBox.Name = "yearAvgBox";
            yearAvgBox.ReadOnly = true;
            yearAvgBox.Size = new Size(75, 23);
            yearAvgBox.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(256, 18);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 14;
            label5.Text = "Six Month";
            // 
            // sixMonthAvgBox
            // 
            sixMonthAvgBox.Location = new Point(255, 37);
            sixMonthAvgBox.Margin = new Padding(4, 3, 4, 3);
            sixMonthAvgBox.Name = "sixMonthAvgBox";
            sixMonthAvgBox.ReadOnly = true;
            sixMonthAvgBox.Size = new Size(75, 23);
            sixMonthAvgBox.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(174, 18);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 12;
            label4.Text = "Three Month";
            // 
            // threeMonthAvgBox
            // 
            threeMonthAvgBox.Location = new Point(173, 37);
            threeMonthAvgBox.Margin = new Padding(4, 3, 4, 3);
            threeMonthAvgBox.Name = "threeMonthAvgBox";
            threeMonthAvgBox.ReadOnly = true;
            threeMonthAvgBox.Size = new Size(75, 23);
            threeMonthAvgBox.TabIndex = 11;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(91, 18);
            label35.Margin = new Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new Size(67, 15);
            label35.TabIndex = 10;
            label35.Text = "This Month";
            // 
            // monthAvgBox
            // 
            monthAvgBox.Location = new Point(90, 37);
            monthAvgBox.Margin = new Padding(4, 3, 4, 3);
            monthAvgBox.Name = "monthAvgBox";
            monthAvgBox.ReadOnly = true;
            monthAvgBox.Size = new Size(75, 23);
            monthAvgBox.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 65);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 8;
            label3.Text = "Daily Avg.";
            // 
            // dailyAvgBox
            // 
            dailyAvgBox.Location = new Point(90, 61);
            dailyAvgBox.Margin = new Padding(4, 3, 4, 3);
            dailyAvgBox.Name = "dailyAvgBox";
            dailyAvgBox.ReadOnly = true;
            dailyAvgBox.Size = new Size(75, 23);
            dailyAvgBox.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(accountNameTextBox);
            groupBox2.Controls.Add(expenseSettingsButton);
            groupBox2.Controls.Add(saveAccountNameButton);
            groupBox2.Controls.Add(accountStartDateTimePicker);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(saveStartDateButton);
            groupBox2.Location = new Point(749, 12);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(422, 115);
            groupBox2.TabIndex = 45;
            groupBox2.TabStop = false;
            groupBox2.Text = "Account Settings";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 21);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 41;
            label2.Text = "Account Name";
            // 
            // accountNameTextBox
            // 
            accountNameTextBox.Location = new Point(128, 17);
            accountNameTextBox.Margin = new Padding(4, 3, 4, 3);
            accountNameTextBox.Name = "accountNameTextBox";
            accountNameTextBox.Size = new Size(116, 23);
            accountNameTextBox.TabIndex = 43;
            // 
            // expenseSettingsButton
            // 
            expenseSettingsButton.Location = new Point(10, 80);
            expenseSettingsButton.Margin = new Padding(4, 3, 4, 3);
            expenseSettingsButton.Name = "expenseSettingsButton";
            expenseSettingsButton.Size = new Size(122, 27);
            expenseSettingsButton.TabIndex = 34;
            expenseSettingsButton.Text = "Expense Ledger";
            expenseSettingsButton.UseVisualStyleBackColor = true;
            expenseSettingsButton.Click += expenseSettingsButton_Click;
            // 
            // saveAccountNameButton
            // 
            saveAccountNameButton.Location = new Point(252, 15);
            saveAccountNameButton.Margin = new Padding(4, 3, 4, 3);
            saveAccountNameButton.Name = "saveAccountNameButton";
            saveAccountNameButton.Size = new Size(88, 27);
            saveAccountNameButton.TabIndex = 42;
            saveAccountNameButton.Text = "Save Name";
            saveAccountNameButton.UseVisualStyleBackColor = true;
            saveAccountNameButton.Click += saveAccountNameButton_Click;
            // 
            // accountStartDateTimePicker
            // 
            accountStartDateTimePicker.Format = DateTimePickerFormat.Short;
            accountStartDateTimePicker.Location = new Point(128, 50);
            accountStartDateTimePicker.Margin = new Padding(4, 3, 4, 3);
            accountStartDateTimePicker.Name = "accountStartDateTimePicker";
            accountStartDateTimePicker.Size = new Size(116, 23);
            accountStartDateTimePicker.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 53);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 38;
            label1.Text = "Account Start Date";
            // 
            // saveStartDateButton
            // 
            saveStartDateButton.Location = new Point(252, 47);
            saveStartDateButton.Margin = new Padding(4, 3, 4, 3);
            saveStartDateButton.Name = "saveStartDateButton";
            saveStartDateButton.Size = new Size(88, 27);
            saveStartDateButton.TabIndex = 39;
            saveStartDateButton.Text = "Save Date";
            saveStartDateButton.UseVisualStyleBackColor = true;
            saveStartDateButton.Click += saveStartDateButton_Click;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.Controls.Add(expenseTypeListBox);
            groupBox3.Controls.Add(clearButton);
            groupBox3.Controls.Add(categoryNewTextBox);
            groupBox3.Controls.Add(categoriesComboBox);
            groupBox3.Controls.Add(viewCategoryButton);
            groupBox3.Controls.Add(saveNewCategoryButton);
            groupBox3.Controls.Add(addButton);
            groupBox3.Controls.Add(listBox1);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(749, 133);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(422, 295);
            groupBox3.TabIndex = 46;
            groupBox3.TabStop = false;
            groupBox3.Text = "Groups";
            // 
            // expenseTypeListBox
            // 
            expenseTypeListBox.FormattingEnabled = true;
            expenseTypeListBox.ItemHeight = 15;
            expenseTypeListBox.Location = new Point(7, 140);
            expenseTypeListBox.Margin = new Padding(4, 3, 4, 3);
            expenseTypeListBox.Name = "expenseTypeListBox";
            expenseTypeListBox.SelectionMode = SelectionMode.MultiSimple;
            expenseTypeListBox.Size = new Size(201, 139);
            expenseTypeListBox.TabIndex = 40;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(327, 106);
            clearButton.Margin = new Padding(4, 3, 4, 3);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(88, 27);
            clearButton.TabIndex = 39;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // categoryNewTextBox
            // 
            categoryNewTextBox.Location = new Point(10, 67);
            categoryNewTextBox.Margin = new Padding(4, 3, 4, 3);
            categoryNewTextBox.Name = "categoryNewTextBox";
            categoryNewTextBox.Size = new Size(261, 23);
            categoryNewTextBox.TabIndex = 38;
            // 
            // categoriesComboBox
            // 
            categoriesComboBox.FormattingEnabled = true;
            categoriesComboBox.Location = new Point(10, 22);
            categoriesComboBox.Margin = new Padding(4, 3, 4, 3);
            categoriesComboBox.Name = "categoriesComboBox";
            categoriesComboBox.Size = new Size(276, 23);
            categoriesComboBox.TabIndex = 37;
            // 
            // viewCategoryButton
            // 
            viewCategoryButton.Location = new Point(294, 20);
            viewCategoryButton.Margin = new Padding(4, 3, 4, 3);
            viewCategoryButton.Name = "viewCategoryButton";
            viewCategoryButton.Size = new Size(121, 27);
            viewCategoryButton.TabIndex = 36;
            viewCategoryButton.Text = "View Category";
            viewCategoryButton.UseVisualStyleBackColor = true;
            viewCategoryButton.Click += viewCategoryButton_Click;
            // 
            // saveNewCategoryButton
            // 
            saveNewCategoryButton.Location = new Point(279, 65);
            saveNewCategoryButton.Margin = new Padding(4, 3, 4, 3);
            saveNewCategoryButton.Name = "saveNewCategoryButton";
            saveNewCategoryButton.Size = new Size(88, 27);
            saveNewCategoryButton.TabIndex = 35;
            saveNewCategoryButton.Text = "Save";
            saveNewCategoryButton.UseVisualStyleBackColor = true;
            saveNewCategoryButton.Click += saveNewCategoryButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(121, 106);
            addButton.Margin = new Padding(4, 3, 4, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(88, 27);
            addButton.TabIndex = 34;
            addButton.Text = "Add ->";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(214, 140);
            listBox1.Margin = new Padding(4, 3, 4, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(201, 139);
            listBox1.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 112);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(77, 15);
            label9.TabIndex = 29;
            label9.Text = "expense Type";
            // 
            // AveragerMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 531);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(expenseAverageRecordDataGridView);
            Name = "AveragerMainForm";
            Text = "i-expense Averager";
            ((System.ComponentModel.ISupportInitialize)expenseAverageRecordDataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView expenseAverageRecordDataGridView;
        private DataGridViewTextBoxColumn ObjectColumn;
        private DataGridViewTextBoxColumn DayColumn;
        private DataGridViewTextBoxColumn DateColumn;
        private DataGridViewTextBoxColumn AmountColumn;
        private DataGridViewTextBoxColumn ExpenseTypeColumn;
        private DataGridViewTextBoxColumn LocationColumn;
        private DataGridViewTextBoxColumn NoteColumn;
        private GroupBox groupBox1;
        private Label label7;
        private TextBox totalAvgBox;
        private Label label6;
        private TextBox yearAvgBox;
        private Label label5;
        private TextBox sixMonthAvgBox;
        private Label label4;
        private TextBox threeMonthAvgBox;
        private Label label35;
        private TextBox monthAvgBox;
        private Label label3;
        private TextBox dailyAvgBox;
        private GroupBox groupBox2;
        private Label label2;
        private TextBox accountNameTextBox;
        private Button expenseSettingsButton;
        private Button saveAccountNameButton;
        private DateTimePicker accountStartDateTimePicker;
        private Label label1;
        private Button saveStartDateButton;
        private GroupBox groupBox3;
        private ListBox expenseTypeListBox;
        private Button clearButton;
        private TextBox categoryNewTextBox;
        private ComboBox categoriesComboBox;
        private Button viewCategoryButton;
        private Button saveNewCategoryButton;
        private Button addButton;
        private ListBox listBox1;
        private Label label9;
    }
}
