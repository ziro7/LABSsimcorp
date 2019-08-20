using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using LABSsimcorp;

namespace DelegateMessageForm {
    public partial class Form1 : Form {

        MobilePhone phone;
        MessageInisiator smsInitiator;
        ListViewOutput output;
        Dictionary<FilterCheckBox, bool> filterDictionary;

        delegate void SetTextCallback(object sender, MessageEventArgs e);
        delegate void SetProgressbar(int change);

        public bool FilterOnUsers { get; set; }
        public string SelectedUserName { get; set; }
        public bool FilterOnMessageText { get; set; }
        public string MessageTextInFilterBoks { get; set; }
        public bool FilterOnDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public Form1() {
            InitializeComponent();
            Setup();
        }

        private void Setup() {
            SetupOutputPhoneAndFilter();
            CreateFilterDictionary();
            PopulateComboBoxOfUsers();
            AttachEventHandlers();
            BatteryPercentageProgressBar.Value = phone.Battery.PercentageCharged;
        }

        private void SetupOutputPhoneAndFilter() {
            output = new ListViewOutput(MessageListView);
            var smsStorage = new MessageStorage();
            phone = new MobilePhone(Model.Iphone10, output, smsStorage);
            IMessageInisiatorFactory smsInisiatorFactory = LoadMessageInisiator();
            smsInitiator = (MessageInisiator)smsInisiatorFactory.CreateMessageInisiator(phone);
            filterDictionary = new Dictionary<FilterCheckBox, bool>();
        }

        private static IMessageInisiatorFactory LoadMessageInisiator() {
            string factornyName = Properties.Settings.Default.MessageInisiatorFactory;
            return Assembly.GetAssembly(typeof(MessageInisiator)).CreateInstance(factornyName) as IMessageInisiatorFactory;
        }

        private void CreateFilterDictionary() {
            filterDictionary.Add(FilterCheckBox.User, FilterOnUsers);
            filterDictionary.Add(FilterCheckBox.Message, FilterOnMessageText);
            filterDictionary.Add(FilterCheckBox.Date, FilterOnDate);
        }

        private void PopulateComboBoxOfUsers() {
            foreach (var user in phone.ContactList) {
                UserComboBox.Items.Add(user.Name);
            }
        }

        private void AttachEventHandlers() {
            phone.Messages.OnMessageStored += MessageReceivedHandler;
            phone.Messages.OnMessageRemoved += MessageRemovedHandler;
            phone.Battery.OnBatteryIsChanging += BatteryChangeingHandler;
        }

        private void MessageRemovedHandler(object sender, MessageEventArgs e) {

            // Bit of recursive defense to make sure it is on correct thread.
            if (this.InvokeRequired) {
                // we are on a worker thread.
                // Set a delegate to the function ro call again.
                var d = new SetTextCallback(MessageRemovedHandler);
                // Now we invoke the form using the same method and input. 
                this.Invoke(d, new object[] { this, e });
            } else {
                DisplaySelectedMessages();
            }
        }

        private void MessageReceivedHandler(object sender, MessageEventArgs e) {

            // Bit of recursive defense to make sure it is on correct thread.
            if (this.InvokeRequired) {
                // we are on a worker thread.
                // Set a delegate to the function ro call again.
                var d = new SetTextCallback(MessageReceivedHandler);
                // Now we invoke the form using the same method and input. 
                this.Invoke(d, new object[] { this, e});
            } else {
                DisplaySelectedMessages();
            }
        }

        private void BatteryChangeingHandler(int obj) {
            if (this.InvokeRequired) {
                var d = new SetProgressbar(BatteryChangeingHandler);
                this.Invoke(d, new object[] { obj });
            } else {
                BatteryPercentageProgressBar.Increment(obj);
            }         
        }

        private void MessageBox_TextChanged(object sender, EventArgs e) {
            //Do anything?
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

            if (comboBox1.Text == "Capitalized") {
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




        private void UpdateFilterDictionary() {
            filterDictionary[FilterCheckBox.User] = FilterOnUsers;
            filterDictionary[FilterCheckBox.Message] = FilterOnMessageText;
            filterDictionary[FilterCheckBox.Date] = FilterOnDate;
        }

        private void UserFilterCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (UserComboBox.SelectedItem != null) {
                FilterOnUsers = !FilterOnUsers;
                SelectedUserName = UserComboBox.SelectedItem.ToString();
                DisplaySelectedMessages();
            } else {
                System.Windows.Forms.MessageBox.Show("Please select a user prior to filter on it.", "Error", MessageBoxButtons.OK);
                UserFilterCheckBox.Checked = FilterOnUsers;
            }

        }

        private void MessageFilterCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (MessageFilterTextBox.Text != "") {
                FilterOnMessageText = !FilterOnMessageText;
                MessageTextInFilterBoks = MessageFilterTextBox.Text;
                DisplaySelectedMessages();
            } else {
                System.Windows.Forms.MessageBox.Show("Please select a message prior to filter on it.", "Error", MessageBoxButtons.OK);
                MessageFilterCheckBox.Checked = FilterOnMessageText;
            }

        }

        private void DateFilterCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (FromDateTimePicker.Value != null && ToDateTimePicker.Value != null) {
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

        private void StartMessageButton_Click(object sender, EventArgs e) {
            smsInitiator.StartService();
        }

        private void StopMessageButton_Click(object sender, EventArgs e) {
            smsInitiator.StopMessages();
        }

        private void ChargeButton_Click(object sender, EventArgs e) {
            phone.Battery.IsCharging = !phone.Battery.IsCharging;

            if (phone.Battery.IsCharging) {
                phone.Battery.Charge();
            } else {
                phone.Battery.Discharge();
            }
        }
    }
}
