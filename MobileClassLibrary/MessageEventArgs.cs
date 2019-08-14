using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABSsimcorp {
    public class MessageEventArgs : System.EventArgs {

        public Message Message { get; set; }

        public MessageEventArgs(Message message) {
            Message = message;
        }
    }
}
