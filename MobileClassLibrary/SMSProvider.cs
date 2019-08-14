using System;
using System.Collections.Generic;
using LABSsimcorpy;

namespace LABSsimcorp {
    public class SMSProvider {

        public List<User> ContactList { get;  set; }

        public event EventHandler<MessageEventArgs> OnSMSReceived;

        public SMSProvider(List<User> contactlist) {
            ContactList = contactlist;
        }

        private void RaiseSMSReceivedEvent () {

            Message randomMessage = GenerateRandomMessage(); //new Message(new LABSsimcorpy.User(1, "Jacob", 12341234), "Sms from jacob", DateTime.Now);

            var handler = OnSMSReceived; //makes it thread safe 
            if (handler != null) {
                handler(this, new MessageEventArgs(randomMessage));
            }
        }

        private Message GenerateRandomMessage() {
            Random random = new Random();
            int userInt = random.Next(0, ContactList.Count);

            string message = string.Format("SMS from {0} received at: {1} {2}", ContactList[userInt].Name, DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());

            return new Message(ContactList[userInt], message, DateTime.Now);
        }

        public void OnTickHandler(object sender, EventArgs e) {
            var message = "Sms recieved at: {0} the following date: {1}"; //TODO Move to SMS
            var messageFormat = string.Format(message, DateTime.Now.ToLongTimeString(),DateTime.Now.ToLongDateString()); //TODO Move to SMS
            RaiseSMSReceivedEvent();            
        }
    }
}
