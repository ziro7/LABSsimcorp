using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LABSsimcorp;

namespace MobileFormVersion {
    class LabelOutput : IOutput {
        public Label OutputLabel { get; set; }

        public LabelOutput(Label label) {
            OutputLabel = label;

        }
        public void Write(string text) {
            OutputLabel.Text = "" + text;
        }

        public void WriteLine(string text) {
            OutputLabel.Text = "" + text + Environment.NewLine;
        }
    }
}
