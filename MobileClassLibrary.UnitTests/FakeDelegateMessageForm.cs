using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LABSsimcorp;

namespace DelegateMessageForm.UnitTests {
    class FakeDelegateMessageForm {
        public Dictionary<FilterCheckBox, bool> FilterDict { get; set; }

        public FakeDelegateMessageForm(Dictionary<FilterCheckBox, bool> filterDict) {
            FilterDict = filterDict;
        }
    }
}
