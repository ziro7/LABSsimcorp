using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class MonoChromeScreen : ScreenBase {

        public MonoChromeScreen(double sizeInInches, int pixelCount) 
            :base(sizeInInches,pixelCount) {
       
        }

        public override void Show(IScreenImage image) {
            Console.WriteLine("Drawing a drawing on MonoChromeScreen - Black and White");
        }

        public override void Show(IScreenImage image, int brightness) {
            Console.WriteLine("Drawing a drawing on MonoChromeScreen - Black and White + brightness: " + brightness);
        }
    }
}
