using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABSsimcorp {
    public class SMSProvider {

        public event Action<string> OnSMSReceived;

        public SMSProvider() {

        }

        private void RaiseSMSReceivedEvent (string message) {
            var handler = OnSMSReceived; //makes it thread safe 
            if (handler != null) {
                handler(message);
            }
        }

        public void OnTickHandler(object sender, EventArgs e) {
            string message = "{0} {1}";
            var messageFormat = string.Format(message, DateTime.Now.ToLongTimeString(),DateTime.Now.ToLongDateString());
            RaiseSMSReceivedEvent(messageFormat);            
        }
    }
}
