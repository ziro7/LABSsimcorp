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

            Message randomMessage = GenerateRandomMessage(); 

            var handler = OnSMSReceived; //makes it thread safe 
            if (handler != null) {
                handler(this, new MessageEventArgs(randomMessage));
            }
        }

        private Message GenerateRandomMessage() {
            Random random = new Random();
            int userInt = random.Next(0, ContactList.Count);

            string message = string.Format("SMS received at: {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());

            return new Message(ContactList[userInt], message, DateTime.Now);
        }

        public void OnTickHandler(object sender, EventArgs e) {
            RaiseSMSReceivedEvent();            
        }
    }
}
