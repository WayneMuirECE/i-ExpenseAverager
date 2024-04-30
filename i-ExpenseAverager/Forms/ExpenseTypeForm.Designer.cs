namespace i_ExpenseAverager.Forms
{
    partial class ExpenseTypeForm
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
            cancelButton = new Button();
            saveButton = new Button();
            label2 = new Label();
            ExpenceAverageDateTimePicker = new DateTimePicker();
            label1 = new Label();
            expenseAverageTypeBox = new ComboBox();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(159, 116);
            cancelButton.Margin = new Padding(4, 3, 4, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(88, 27);
            cancelButton.TabIndex = 25;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(64, 116);
            saveButton.Margin = new Padding(4, 3, 4, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(88, 27);
            saveButton.TabIndex = 24;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 56);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 23;
            label2.Text = "Record Start Date";
            // 
            // ExpenceAverageDateTimePicker
            // 
            ExpenceAverageDateTimePicker.Location = new Point(13, 74);
            ExpenceAverageDateTimePicker.Margin = new Padding(4, 3, 4, 3);
            ExpenceAverageDateTimePicker.Name = "ExpenceAverageDateTimePicker";
            ExpenceAverageDateTimePicker.Size = new Size(233, 23);
            ExpenceAverageDateTimePicker.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 21;
            label1.Text = "Expence Type";
            // 
            // expenceAverageTypeBox
            // 
            expenseAverageTypeBox.FormattingEnabled = true;
            expenseAverageTypeBox.Location = new Point(13, 28);
            expenseAverageTypeBox.Margin = new Padding(4, 3, 4, 3);
            expenseAverageTypeBox.Name = "expenceAverageTypeBox";
            expenseAverageTypeBox.Size = new Size(233, 23);
            expenseAverageTypeBox.TabIndex = 20;
            // 
            // ExpenseTypeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(label2);
            Controls.Add(ExpenceAverageDateTimePicker);
            Controls.Add(label1);
            Controls.Add(expenseAverageTypeBox);
            Name = "ExpenseTypeForm";
            Text = "ExpenceAverageTypeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button saveButton;
        private Label label2;
        private DateTimePicker ExpenceAverageDateTimePicker;
        private Label label1;
        private ComboBox expenseAverageTypeBox;
    }
}