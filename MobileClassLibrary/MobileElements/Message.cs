using System;

namespace LABSsimcorp {
    public class Message {

        public Contact User { get; set; }
        public string Text { get; set; }
        public DateTime ReceivingTime { get; set; }

        public Message(Contact user, string text, DateTime receivedAt) {
            User = user;
            Text = text;
            ReceivingTime = receivedAt; 

        }
    }
}
