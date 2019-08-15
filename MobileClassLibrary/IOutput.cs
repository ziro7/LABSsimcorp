using System.Collections.Generic;

namespace LABSsimcorp {
    public interface IOutput {
        void Write(string text);
        void WriteLine(string text);
        void WriteLine(List<Message> messages, MobilePhone.FormatDelegate formatter);
    }
}
