namespace MobileFormVersion {
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
            this.HeadPhonesRadioButton = new System.Windows.Forms.RadioButton();
            this.SpeakersRadioButton = new System.Windows.Forms.RadioButton();
            this.PhoneSpeakerRadioButton = new System.Windows.Forms.RadioButton();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HeadPhonesRadioButton
            // 
            this.HeadPhonesRadioButton.AutoSize = true;
            this.HeadPhonesRadioButton.Location = new System.Drawing.Point(46, 49);
            this.HeadPhonesRadioButton.Name = "HeadPhonesRadioButton";
            this.HeadPhonesRadioButton.Size = new System.Drawing.Size(126, 24);
            this.HeadPhonesRadioButton.TabIndex = 0;
            this.HeadPhonesRadioButton.TabStop = true;
            this.HeadPhonesRadioButton.Text = "Headphones";
            this.HeadPhonesRadioButton.UseVisualStyleBackColor = true;
            // 
            // SpeakersRadioButton
            // 
            this.SpeakersRadioButton.AutoSize = true;
            this.SpeakersRadioButton.Location = new System.Drawing.Point(46, 79);
            this.SpeakersRadioButton.Name = "SpeakersRadioButton";
            this.SpeakersRadioButton.Size = new System.Drawing.Size(102, 24);
            this.SpeakersRadioButton.TabIndex = 1;
            this.SpeakersRadioButton.TabStop = true;
            this.SpeakersRadioButton.Text = "Speakers";
            this.SpeakersRadioButton.UseVisualStyleBackColor = true;
            // 
            // PhoneSpeakerRadioButton
            // 
            this.PhoneSpeakerRadioButton.AutoSize = true;
            this.PhoneSpeakerRadioButton.Location = new System.Drawing.Point(46, 109);
            this.PhoneSpeakerRadioButton.Name = "PhoneSpeakerRadioButton";
            this.PhoneSpeakerRadioButton.Size = new System.Drawing.Size(145, 24);
            this.PhoneSpeakerRadioButton.TabIndex = 2;
            this.PhoneSpeakerRadioButton.TabStop = true;
            this.PhoneSpeakerRadioButton.Text = "Phonespeakers";
            this.PhoneSpeakerRadioButton.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(254, 109);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(92, 38);
            this.ApplyButton.TabIndex = 4;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // OutputLabel
            // 
            this.OutputLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.OutputLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputLabel.Location = new System.Drawing.Point(46, 173);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(300, 265);
            this.OutputLabel.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 507);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.PhoneSpeakerRadioButton);
            this.Controls.Add(this.SpeakersRadioButton);
            this.Controls.Add(this.HeadPhonesRadioButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton HeadPhonesRadioButton;
        private System.Windows.Forms.RadioButton SpeakersRadioButton;
        private System.Windows.Forms.RadioButton PhoneSpeakerRadioButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label OutputLabel;
    }
}

