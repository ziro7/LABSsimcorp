using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABSsimcorp {
    public class MessageInisiatorTaskFactory : IMessageInisiatorFactory {
        public IMessageInisiator CreateMessageInisiator(MobilePhone phone) => new TaskMessageInisiator(phone);
    }
}
