namespace CallListDisplayForm {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.CallListView = new System.Windows.Forms.ListView();
            this.ContactComboBox = new System.Windows.Forms.ComboBox();
            this.CallTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CreateCallButton = new System.Windows.Forms.Button();
            this.IncommingCallCheckBox = new System.Windows.Forms.CheckBox();
            this.SelectUserLabel = new System.Windows.Forms.Label();
            this.CallTimeLabel = new System.Windows.Forms.Label();
            this.IncommingRadioButton = new System.Windows.Forms.RadioButton();
            this.OutgoingRadioButton = new System.Windows.Forms.RadioButton();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NumbersTextBox = new System.Windows.Forms.RichTextBox();
            this.Contact = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CallTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // CallListView
            // 
            this.CallListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Contact,
            this.CallTime,
            this.Number});
            this.CallListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.CallListView.Location = new System.Drawing.Point(24, 173);
            this.CallListView.Name = "CallListView";
            this.CallListView.Size = new System.Drawing.Size(530, 180);
            this.CallListView.TabIndex = 0;
            this.CallListView.UseCompatibleStateImageBehavior = false;
            this.CallListView.View = System.Windows.Forms.View.Details;
            // 
            // ContactComboBox
            // 
            this.ContactComboBox.FormattingEnabled = true;
            this.ContactComboBox.Location = new System.Drawing.Point(162, 44);
            this.ContactComboBox.Name = "ContactComboBox";
            this.ContactComboBox.Size = new System.Drawing.Size(189, 21);
            this.ContactComboBox.TabIndex = 2;
            this.ContactComboBox.SelectedIndexChanged += new System.EventHandler(this.ContactComboBox_SelectedIndexChanged);
            // 
            // CallTimeDateTimePicker
            // 
            this.CallTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.CallTimeDateTimePicker.Location = new System.Drawing.Point(162, 71);
            this.CallTimeDateTimePicker.Name = "CallTimeDateTimePicker";
            this.CallTimeDateTimePicker.Size = new System.Drawing.Size(189, 20);
            this.CallTimeDateTimePicker.TabIndex = 3;
            this.CallTimeDateTimePicker.Value = new System.DateTime(2019, 8, 23, 10, 40, 6, 0);
            this.CallTimeDateTimePicker.ValueChanged += new System.EventHandler(this.CallTimeDateTimePicker_ValueChanged);
            // 
            // CreateCallButton
            // 
            this.CreateCallButton.Location = new System.Drawing.Point(276, 122);
            this.CreateCallButton.Name = "CreateCallButton";
            this.CreateCallButton.Size = new System.Drawing.Size(75, 23);
            this.CreateCallButton.TabIndex = 4;
            this.CreateCallButton.Text = "Create Call";
            this.CreateCallButton.UseVisualStyleBackColor = true;
            this.CreateCallButton.Click += new System.EventHandler(this.CreateCallButton_Click);
            // 
            // IncommingCallCheckBox
            // 
            this.IncommingCallCheckBox.AutoSize = true;
            this.IncommingCallCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IncommingCallCheckBox.Checked = true;
            this.IncommingCallCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncommingCallCheckBox.Location = new System.Drawing.Point(20, 126);
            this.IncommingCallCheckBox.Name = "IncommingCallCheckBox";
            this.IncommingCallCheckBox.Size = new System.Drawing.Size(155, 17);
            this.IncommingCallCheckBox.TabIndex = 5;
            this.IncommingCallCheckBox.Text = "Check if it is incomming call";
            this.IncommingCallCheckBox.UseVisualStyleBackColor = true;
            this.IncommingCallCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SelectUserLabel
            // 
            this.SelectUserLabel.AutoSize = true;
            this.SelectUserLabel.Location = new System.Drawing.Point(21, 47);
            this.SelectUserLabel.Name = "SelectUserLabel";
            this.SelectUserLabel.Size = new System.Drawing.Size(77, 13);
            this.SelectUserLabel.TabIndex = 6;
            this.SelectUserLabel.Text = "Select Contact";
            this.SelectUserLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // CallTimeLabel
            // 
            this.CallTimeLabel.AutoSize = true;
            this.CallTimeLabel.Location = new System.Drawing.Point(21, 77);
            this.CallTimeLabel.Name = "CallTimeLabel";
            this.CallTimeLabel.Size = new System.Drawing.Size(78, 13);
            this.CallTimeLabel.TabIndex = 7;
            this.CallTimeLabel.Text = "Select call time";
            // 
            // IncommingRadioButton
            // 
            this.IncommingRadioButton.AutoSize = true;
            this.IncommingRadioButton.Location = new System.Drawing.Point(24, 150);
            this.IncommingRadioButton.Name = "IncommingRadioButton";
            this.IncommingRadioButton.Size = new System.Drawing.Size(101, 17);
            this.IncommingRadioButton.TabIndex = 8;
            this.IncommingRadioButton.TabStop = true;
            this.IncommingRadioButton.Text = "Incomming Calls";
            this.IncommingRadioButton.UseVisualStyleBackColor = true;
            this.IncommingRadioButton.CheckedChanged += new System.EventHandler(this.IncommingRadioButton_CheckedChanged);
            // 
            // OutgoingRadioButton
            // 
            this.OutgoingRadioButton.AutoSize = true;
            this.OutgoingRadioButton.Location = new System.Drawing.Point(131, 150);
            this.OutgoingRadioButton.Name = "OutgoingRadioButton";
            this.OutgoingRadioButton.Size = new System.Drawing.Size(93, 17);
            this.OutgoingRadioButton.TabIndex = 9;
            this.OutgoingRadioButton.TabStop = true;
            this.OutgoingRadioButton.Text = "Outgoing Calls";
            this.OutgoingRadioButton.UseVisualStyleBackColor = true;
            this.OutgoingRadioButton.CheckedChanged += new System.EventHandler(this.OutgoingRadioButton_CheckedChanged);
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(162, 98);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(189, 20);
            this.PhoneTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select phoneNumber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Known Numbers";
            // 
            // NumbersTextBox
            // 
            this.NumbersTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.NumbersTextBox.Location = new System.Drawing.Point(360, 63);
            this.NumbersTextBox.Name = "NumbersTextBox";
            this.NumbersTextBox.ReadOnly = true;
            this.NumbersTextBox.Size = new System.Drawing.Size(194, 80);
            this.NumbersTextBox.TabIndex = 14;
            this.NumbersTextBox.Text = "";
            // 
            // Contact
            // 
            this.Contact.Text = "Contact";
            this.Contact.Width = 114;
            // 
            // CallTime
            // 
            this.CallTime.Text = "Call time";
            this.CallTime.Width = 97;
            // 
            // Number
            // 
            this.Number.Text = "Number";
            this.Number.Width = 102;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(587, 391);
            this.Controls.Add(this.NumbersTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.OutgoingRadioButton);
            this.Controls.Add(this.IncommingRadioButton);
            this.Controls.Add(this.CallTimeLabel);
            this.Controls.Add(this.SelectUserLabel);
            this.Controls.Add(this.IncommingCallCheckBox);
            this.Controls.Add(this.CreateCallButton);
            this.Controls.Add(this.CallTimeDateTimePicker);
            this.Controls.Add(this.ContactComboBox);
            this.Controls.Add(this.CallListView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView CallListView;
        private System.Windows.Forms.ComboBox ContactComboBox;
        private System.Windows.Forms.DateTimePicker CallTimeDateTimePicker;
        private System.Windows.Forms.Button CreateCallButton;
        private System.Windows.Forms.CheckBox IncommingCallCheckBox;
        private System.Windows.Forms.Label SelectUserLabel;
        private System.Windows.Forms.Label CallTimeLabel;
        private System.Windows.Forms.RadioButton IncommingRadioButton;
        private System.Windows.Forms.RadioButton OutgoingRadioButton;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox NumbersTextBox;
        private System.Windows.Forms.ColumnHeader Contact;
        private System.Windows.Forms.ColumnHeader CallTime;
        private System.Windows.Forms.ColumnHeader Number;
    }
}

