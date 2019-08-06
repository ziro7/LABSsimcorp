using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    public class Keyboard {
        public bool SupportEmoji { get; set; }

        public Keyboard(bool supportEmoji) {
            SupportEmoji = supportEmoji;
        }
    }
}
