using System;

namespace LABSsimcorp {
    public class Message {

        public User User { get; set; }
        public string Text { get; set; }
        public DateTime ReceivingTime { get; set; }

        public Message(User user, string text, DateTime receivedAt) {
            User = user;
            Text = text;
            ReceivingTime = receivedAt; 

        }
    }
}
