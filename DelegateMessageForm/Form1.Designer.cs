namespace DelegateMessageForm {
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
            this.MessageBox = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.MessageFilterTextBox = new System.Windows.Forms.TextBox();
            this.UserComboBox = new System.Windows.Forms.ComboBox();
            this.UserFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.MessageFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.DateFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MessageListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartMessageButton = new System.Windows.Forms.Button();
            this.StopMessageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(12, 417);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(467, 112);
            this.MessageBox.TabIndex = 0;
            this.MessageBox.Text = "";
            this.MessageBox.TextChanged += new System.EventHandler(this.MessageBox_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Capitalized",
            "Reverse Capitalized",
            "Sort",
            "Shorten",
            "Replace"});
            this.comboBox1.Location = new System.Drawing.Point(12, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // FromDateTimePicker
            // 
            this.FromDateTimePicker.Location = new System.Drawing.Point(306, 91);
            this.FromDateTimePicker.Name = "FromDateTimePicker";
            this.FromDateTimePicker.Size = new System.Drawing.Size(84, 20);
            this.FromDateTimePicker.TabIndex = 2;
            // 
            // ToDateTimePicker
            // 
            this.ToDateTimePicker.Location = new System.Drawing.Point(395, 91);
            this.ToDateTimePicker.Name = "ToDateTimePicker";
            this.ToDateTimePicker.Size = new System.Drawing.Size(84, 20);
            this.ToDateTimePicker.TabIndex = 3;
            // 
            // MessageFilterTextBox
            // 
            this.MessageFilterTextBox.Location = new System.Drawing.Point(306, 65);
            this.MessageFilterTextBox.Name = "MessageFilterTextBox";
            this.MessageFilterTextBox.Size = new System.Drawing.Size(173, 20);
            this.MessageFilterTextBox.TabIndex = 4;
            // 
            // UserComboBox
            // 
            this.UserComboBox.FormattingEnabled = true;
            this.UserComboBox.Location = new System.Drawing.Point(306, 38);
            this.UserComboBox.Name = "UserComboBox";
            this.UserComboBox.Size = new System.Drawing.Size(173, 21);
            this.UserComboBox.TabIndex = 5;
            // 
            // UserFilterCheckBox
            // 
            this.UserFilterCheckBox.AutoSize = true;
            this.UserFilterCheckBox.Location = new System.Drawing.Point(285, 41);
            this.UserFilterCheckBox.Name = "UserFilterCheckBox";
            this.UserFilterCheckBox.Size = new System.Drawing.Size(15, 14);
            this.UserFilterCheckBox.TabIndex = 6;
            this.UserFilterCheckBox.UseVisualStyleBackColor = true;
            this.UserFilterCheckBox.CheckedChanged += new System.EventHandler(this.UserFilterCheckBox_CheckedChanged);
            // 
            // MessageFilterCheckBox
            // 
            this.MessageFilterCheckBox.AutoSize = true;
            this.MessageFilterCheckBox.Location = new System.Drawing.Point(285, 68);
            this.MessageFilterCheckBox.Name = "MessageFilterCheckBox";
            this.MessageFilterCheckBox.Size = new System.Drawing.Size(15, 14);
            this.MessageFilterCheckBox.TabIndex = 7;
            this.MessageFilterCheckBox.UseVisualStyleBackColor = true;
            this.MessageFilterCheckBox.CheckedChanged += new System.EventHandler(this.MessageFilterCheckBox_CheckedChanged);
            // 
            // DateFilterCheckBox
            // 
            this.DateFilterCheckBox.AutoSize = true;
            this.DateFilterCheckBox.Location = new System.Drawing.Point(285, 93);
            this.DateFilterCheckBox.Name = "DateFilterCheckBox";
            this.DateFilterCheckBox.Size = new System.Drawing.Size(15, 14);
            this.DateFilterCheckBox.TabIndex = 8;
            this.DateFilterCheckBox.UseVisualStyleBackColor = true;
            this.DateFilterCheckBox.CheckedChanged += new System.EventHandler(this.DateFilterCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Filter by:";
            // 
            // MessageListView
            // 
            this.MessageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MessageListView.Location = new System.Drawing.Point(12, 129);
            this.MessageListView.Name = "MessageListView";
            this.MessageListView.Size = new System.Drawing.Size(467, 282);
            this.MessageListView.TabIndex = 10;
            this.MessageListView.UseCompatibleStateImageBehavior = false;
            this.MessageListView.View = System.Windows.Forms.View.Tile;
            // 
            // StartMessageButton
            // 
            this.StartMessageButton.Location = new System.Drawing.Point(13, 38);
            this.StartMessageButton.Name = "StartMessageButton";
            this.StartMessageButton.Size = new System.Drawing.Size(75, 23);
            this.StartMessageButton.TabIndex = 11;
            this.StartMessageButton.Text = "Start";
            this.StartMessageButton.UseVisualStyleBackColor = true;
            this.StartMessageButton.Click += new System.EventHandler(this.StartMessageButton_Click);
            // 
            // StopMessageButton
            // 
            this.StopMessageButton.Location = new System.Drawing.Point(94, 38);
            this.StopMessageButton.Name = "StopMessageButton";
            this.StopMessageButton.Size = new System.Drawing.Size(75, 23);
            this.StopMessageButton.TabIndex = 12;
            this.StopMessageButton.Text = "Stop";
            this.StopMessageButton.UseVisualStyleBackColor = true;
            this.StopMessageButton.Click += new System.EventHandler(this.StopMessageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 560);
            this.Controls.Add(this.StopMessageButton);
            this.Controls.Add(this.StartMessageButton);
            this.Controls.Add(this.MessageListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateFilterCheckBox);
            this.Controls.Add(this.MessageFilterCheckBox);
            this.Controls.Add(this.UserFilterCheckBox);
            this.Controls.Add(this.UserComboBox);
            this.Controls.Add(this.MessageFilterTextBox);
            this.Controls.Add(this.ToDateTimePicker);
            this.Controls.Add(this.FromDateTimePicker);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.MessageBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox MessageBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker FromDateTimePicker;
        private System.Windows.Forms.DateTimePicker ToDateTimePicker;
        private System.Windows.Forms.TextBox MessageFilterTextBox;
        private System.Windows.Forms.ComboBox UserComboBox;
        private System.Windows.Forms.CheckBox UserFilterCheckBox;
        private System.Windows.Forms.CheckBox MessageFilterCheckBox;
        private System.Windows.Forms.CheckBox DateFilterCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView MessageListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button StartMessageButton;
        private System.Windows.Forms.Button StopMessageButton;
    }
}

