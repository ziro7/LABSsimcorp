using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    public class TouchKeyboard : Keyboard {
        public bool IsMultiTouch { get; set; }

        public TouchKeyboard(bool supportEmoji, bool isMultiTouch) 
            : base(supportEmoji) {
            IsMultiTouch = isMultiTouch;
        }
    }
}
