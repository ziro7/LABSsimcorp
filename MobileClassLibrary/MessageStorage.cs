using System;
using System.Collections.Generic;


namespace LABSsimcorp {
    public class MessageStorage : ISMSStorage{
        public List<Message> MessagesList { get; set; }

        public MessageStorage() {
            MessagesList = new List<Message>();
            AttachOnSMSProcessedHandler();
        }

        private void AttachOnSMSProcessedHandler() {
            SMSProvider.OnSMSProcessed += AddHandler;
        }

        public void AddHandler(object sender, MessageEventArgs e) {
            MessagesList.Add(e.Message);
            OnMessageStored?.Invoke(this, new MessageEventArgs(e.Message));
        }

        public void Add(Message message) {
            MessagesList.Add(message);
            OnMessageStored?.Invoke(this, new MessageEventArgs(message));
        }

        public void Remove (Message message) {
            MessagesList.Remove(message);
            OnMessageRemoved?.Invoke(this, new MessageEventArgs(message));
        }

        public event EventHandler<MessageEventArgs> OnMessageStored;
        public event EventHandler<MessageEventArgs> OnMessageRemoved;
    }
}
