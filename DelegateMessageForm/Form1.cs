using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LABSsimcorp;

namespace DelegateMessageForm {
    public partial class Form1 : Form {

        static Timer myTimer = new Timer();
        LabelOutput output;
        MobilePhone phone;

        public Form1() {
            InitializeComponent();
            SendMessage();
        }

        private void SendMessage() {
            
            output = new LabelOutput(MessageBox);
            phone = new MobilePhone(Model.Iphone10, output);

            output.WriteLine("Starting Messages every 2 sec");

            myTimer.Tick += phone.SMSProviderInstance.OnTickHandler;
            myTimer.Interval = 2000;
            myTimer.Start();
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
