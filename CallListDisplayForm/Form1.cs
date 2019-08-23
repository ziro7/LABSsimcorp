using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LABSsimcorp;

namespace CallListDisplayForm {
    public partial class Form1 : Form {

        MobilePhone phone;
        ListViewOutput output;

        public Form1() {
            InitializeComponent();
            Setup();
        }

        private void Setup() {
            SetupOutputPhone();
            PopulateComboBoxOfUsers();
        }

        private void SetupOutputPhone() {
            output = new ListViewOutput(CallListView);
            var smsStorage = new MessageStorage();
            phone = new MobilePhone(Model.Iphone10, output, smsStorage);
        }

        private void PopulateComboBoxOfUsers() {
            foreach (var user in phone.ContactList) {
                ContactComboBox.Items.Add(user.Name);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {
            //misclick
        }

        private void ContactComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Contact contact = GetContactFromContactName();
            var text = new StringBuilder();
            text.Append(contact.MainPhoneNumber);
            foreach (var number in contact.AdditionalPhoneNumbers) {
                text.Append(", " + number.ToString());
            }
            NumbersTextBox.Text = text.ToString();
        }

        private void CallTimeDateTimePicker_ValueChanged(object sender, EventArgs e) {
            //Todo?
        }

        private void CreateCallButton_Click(object sender, EventArgs e) {
            Contact contact = GetContactFromContactName();
            var callTime = CallTimeDateTimePicker.Value;
            int phoneNumber = GetPhoneNumberFromInput();

            if (IncommingCallCheckBox.Checked) {
                phone.CallList.AddIncommingCall(new Call(contact, phoneNumber, callTime));
            } else {
                phone.CallList.AddOutgoingCall(new Call(contact, phoneNumber, callTime));
            }

            DisplayNewCallIfCorrectViewSelected();
        }

        private void DisplayNewCallIfCorrectViewSelected() {
            if (IncommingCallCheckBox.Checked && IncommingRadioButton.Checked) {
                output.WriteLine(phone.CallList.incommingCallList);
            }

            if (!IncommingCallCheckBox.Checked && OutgoingRadioButton.Checked) {
                output.WriteLine(phone.CallList.outgoingCallList);
            }
        }

        private Contact GetContactFromContactName() {
            try {
                var contactName = ContactComboBox.SelectedItem.ToString();
                var contact = phone.ContactList.Where(c => c.Name == contactName).FirstOrDefault();
                return contact;
            } catch (Exception) {

                MessageBox.Show("Invalid selection", "Error", MessageBoxButtons.OK);
                return null;
            }
        }

        private int GetPhoneNumberFromInput() {
            try {
                int phoneNumber = int.Parse(PhoneTextBox.Text);
                return phoneNumber;
            } catch (FormatException) {
                MessageBox.Show("Invalid phoneNumber", "Error", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void IncommingRadioButton_CheckedChanged(object sender, EventArgs e) {
            output.WriteLine(phone.CallList.incommingCallList);
        }

        private void OutgoingRadioButton_CheckedChanged(object sender, EventArgs e) {
            output.WriteLine(phone.CallList.outgoingCallList);
        }
    }
}
