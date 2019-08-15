using System;
using System.Collections.Generic;
using System.Text;
using LABSsimcorp;

namespace MobileClassLibrary.UnitTest {
    class FakeOutput : IOutput {
        public string WriteText { get; set; }
        public string WriteLineText { get; set; }

        public void Write(string text) {
            WriteText = text;
        }

        public void WriteLine(string text) {
            WriteLineText = text;
        }

        public void WriteLine(List<Message> messages, MobilePhone.FormatDelegate formatter) {
            var stringtext = "";

            foreach (Message message in messages) {
                stringtext += message.Text;
            }

            WriteLine(formatter.Invoke(stringtext));
        }
    }
}
