using System;

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
            var message = "Sms recieved at: {0} the following date: {1}";
            var messageFormat = string.Format(message, DateTime.Now.ToLongTimeString(),DateTime.Now.ToLongDateString());
            RaiseSMSReceivedEvent(messageFormat);            
        }
    }
}
