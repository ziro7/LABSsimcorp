using System;
using System.Collections.Generic;


namespace LABSsimcorp {
    public class MessageStorage {
        public List<Message> MessagesList { get; set; }
        public List<User> ContactList { get; set; }

        public event EventHandler<MessageEventArgs> OnMessageReceived;
        public event EventHandler<MessageEventArgs> OnMessageRemoved;

        public MessageStorage(List<User> contactlist) {
            MessagesList = new List<Message>();
            ContactList = contactlist;
        }

        public void Add(Message message) {
            MessagesList.Add(message);
            OnMessageReceived?.Invoke(this, new MessageEventArgs(message));
        }

        public void Remove (Message message) {
            MessagesList.Remove(message);
            OnMessageRemoved?.Invoke(this, new MessageEventArgs(message));
        }

        public void OnTickHandler(object sender, EventArgs e) {
            var message = GenerateRandomMessage();

            Add(message);
        }

        private Message GenerateRandomMessage() {
            Random random = new Random();
            int userInt = random.Next(0, ContactList.Count);

            string message = string.Format("SMS received at: {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());

            return new Message(ContactList[userInt], message, DateTime.Now);
        }


    }
}
