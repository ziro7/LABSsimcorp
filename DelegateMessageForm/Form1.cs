using System;
using System.Windows.Forms;
using LABSsimcorp;

namespace DelegateMessageForm {
    public partial class Form1 : Form {

        static Timer myTimer = new Timer();
        //LabelOutput output;
        MobilePhone phone;
        ListViewOutput output;

        public Form1() {
            InitializeComponent();
            SendMessage();
        }

        private void SendMessage() {

            output = new ListViewOutput(MessageListView);
            phone = new MobilePhone(Model.Iphone10, output);
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
    }
}
