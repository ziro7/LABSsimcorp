using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class Keyboard {
        public bool IsPhysical { get; set; }

        public Keyboard(bool isPhysical) {
            IsPhysical = isPhysical;
        }
    }
}
