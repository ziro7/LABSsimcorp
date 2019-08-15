using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LABSsimcorp;
using LABSsimcorpy;

namespace DelegateMessageForm {
    public partial class Form1 : Form {

        static Timer myTimer = new Timer();
        //LabelOutput output;
        MobilePhone phone;
        ListViewOutput output;
        Dictionary<FilterCheckBox,bool> filterDictionary;

        public bool FilterOnUsers { get; set; }
        public string SelectedUserName { get; set; }
        public bool FilterOnMessageText { get; set; }
        public string MessageTextInFilterBoks { get; set; }
        public bool FilterOnDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public Form1() {
            InitializeComponent();
            SendMessage();
        }

        private void SendMessage() {

            output = new ListViewOutput(MessageListView);
            phone = new MobilePhone(Model.Iphone10, output);
            filterDictionary = new Dictionary<FilterCheckBox, bool>();
            CreateFilterDictionary();
            PopulateComboBoxOfUsers();

            output.WriteLine("Starting Messages every 1 sec");

            AttachOnTickEventHandler();
            myTimer.Interval = 1000;
            myTimer.Start();
        }

        private void PopulateComboBoxOfUsers() {
            foreach (var user in phone.ContactList) {
                UserComboBox.Items.Add(user.Name);
            }
        }

        private void AttachOnTickEventHandler() {
            myTimer.Tick += phone.SMSProviderInstance.OnTickHandler;
        }

        private void MessageBox_TextChanged(object sender, EventArgs e) {
            //Do anything?
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            
            if(comboBox1.Text == "Capitalized") {
                output.WriteLine("Writing the texts as: Capitalized");
                phone.ChangeFormat(OutputFormat.FormatToUpper);
            }

            if (comboBox1.Text == "Reverse Capitalized") {
                output.WriteLine("Writing the texts as: Reverse Capitalized");
                phone.ChangeFormat(OutputFormat.FormatToLower);
            }


            if (comboBox1.Text == "Sort") {
                output.WriteLine("Writing the texts as: Sort");
                phone.ChangeFormat(OutputFormat.FormatFunish);
            }

            if (comboBox1.Text == "Shorten") {
                output.WriteLine("Writing the texts as: Shorten");
                phone.ChangeFormat(OutputFormat.FormatShorten);
            }

            if (comboBox1.Text == "Replace") {
                output.WriteLine("Writing the texts as: Replace");
                phone.ChangeFormat(OutputFormat.FormatReplacer);
            }
        }


        private void CreateFilterDictionary() {
            filterDictionary.Add(FilterCheckBox.User, FilterOnUsers);
            filterDictionary.Add(FilterCheckBox.Message, FilterOnMessageText);
            filterDictionary.Add(FilterCheckBox.Date, FilterOnDate);
        }

        private void UpdateFilterDictionary() {
            filterDictionary[FilterCheckBox.User] = FilterOnUsers;
            filterDictionary[FilterCheckBox.Message] = FilterOnMessageText;
            filterDictionary[FilterCheckBox.Date] = FilterOnDate;
        }

        private void UserFilterCheckBox_CheckedChanged(object sender, EventArgs e) {
            if(UserComboBox.SelectedItem != null) {
                FilterOnUsers = !FilterOnUsers;
                SelectedUserName = UserComboBox.SelectedItem.ToString();
                DisplaySelectedMessages();
            } else {
                System.Windows.Forms.MessageBox.Show("Please select a user prior to filter on it.", "Error", MessageBoxButtons.OK);
                UserFilterCheckBox.Checked = FilterOnUsers;
            }
            
        }

        private void MessageFilterCheckBox_CheckedChanged(object sender, EventArgs e) {
            if(MessageFilterTextBox.Text != "") {
                FilterOnMessageText = !FilterOnMessageText;
                MessageTextInFilterBoks = MessageFilterTextBox.Text;
                DisplaySelectedMessages();
            } else {
                System.Windows.Forms.MessageBox.Show("Please select a message prior to filter on it.", "Error", MessageBoxButtons.OK);
                MessageFilterCheckBox.Checked = FilterOnMessageText;
            }

        }

        private void DateFilterCheckBox_CheckedChanged(object sender, EventArgs e) {
            if(FromDateTimePicker.Value != null && ToDateTimePicker.Value != null) {
                FilterOnDate = !FilterOnDate;
                FromDate = FromDateTimePicker.Value;
                ToDate = ToDateTimePicker.Value;
                DisplaySelectedMessages();
            } else {
                System.Windows.Forms.MessageBox.Show("Please select a To and a From Date prior to filter on it.", "Error", MessageBoxButtons.OK);
                MessageFilterCheckBox.Checked = FilterOnMessageText;
            }

        }

        private void DisplaySelectedMessages() {
            UpdateFilterDictionary();
            phone.ViewMessages(filterDictionary, new FilterValueDTO(SelectedUserName, MessageTextInFilterBoks, FromDate, ToDate));
        }
    }
}
