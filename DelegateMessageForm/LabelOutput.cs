﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LABSsimcorp;

namespace DelegateMessageForm {
    class LabelOutput : IOutput {
        public RichTextBox Messagebox { get; set; }

        public LabelOutput(RichTextBox messagebox) {
            Messagebox = messagebox;

        }
        public void Write(string text) {
            Messagebox.Text += "" + text;
        }

        public void WriteLine(string text) {
            Messagebox.Text += "" + text + Environment.NewLine;
        }
    }
}
