using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class MonoChromeScreen : ScreenBase {
        public override void Show(IScreenImage image) {
            Console.WriteLine("Drawing a drawing on MonoChromeScreen - Black and White");
        }
    }
}
