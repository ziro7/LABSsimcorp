using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABSsimcorp {
    public class MessageInisiatorThreadFactory : IMessageInisiatorFactory {
        public IMessageInisiator CreateMessageInisiator(MobilePhone phone) => new ThreadMessageInisiator(phone); 
    }
}
