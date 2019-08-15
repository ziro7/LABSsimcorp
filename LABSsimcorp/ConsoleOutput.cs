using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class ConsoleOutput : IOutput {
        public void Write(string text) {
            Console.Write(text);
        }

        public void WriteLine(string text) {
            Console.WriteLine(text);
        }

        public void WriteLine(List<Message> messages, MobilePhone.FormatDelegate formatter) {
            throw new NotImplementedException();
        }
    }
}
