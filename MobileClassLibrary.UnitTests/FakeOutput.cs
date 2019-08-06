using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LABSsimcorp;

namespace MobileClassLibrary.UnitTests {
    class FakeOutput : IOutput {
        public string WriteText { get; set; }
        public string WriteLineText { get; set; }

        public void Write(string text) {
            WriteText = text;
        }

        public void WriteLine(string text) {
            WriteLineText = text;
        }
    }
}
