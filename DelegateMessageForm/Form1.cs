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

        public Form1() {
            InitializeComponent();
            SendMessage();
        }

        private void SendMessage() {
            
            var output = new LabelOutput(MessageBox);
            var phone = new MobilePhone(Model.Iphone10, output);

            output.WriteLine("Starting Messages every 2 sec");

            myTimer.Tick += phone.SMSProviderInstance.OnTickHandler;
            myTimer.Interval = 2000;
            myTimer.Start();
        }

        private void MessageBox_TextChanged(object sender, EventArgs e) {
            //Do anything?
        }
    }
}
