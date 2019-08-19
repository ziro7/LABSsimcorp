using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABSsimcorp {
    public interface ISMSStorage {

        List<Message> MessagesList { get; set; }

        event EventHandler<MessageEventArgs> OnMessageStored;
        event EventHandler<MessageEventArgs> OnMessageRemoved;

        void Add(Message message);
        void Remove(Message message);
    }
}
