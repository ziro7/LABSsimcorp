using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABSsimcorp {
    public interface IMessageInisiatorFactory {
        IMessageInisiator CreateMessageInisiator(MobilePhone phone);
    }
}
