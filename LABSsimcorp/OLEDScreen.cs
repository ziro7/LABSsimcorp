using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class OLEDScreen : ColorfullScreen{

        public OLEDScreen(double sizeInInches, int pixelCount) 
            :base(sizeInInches,pixelCount) {

        }
        public override void Show(IScreenImage image) {
            Console.WriteLine("Image in color - OLED Screen");
        }

        public override void Show(IScreenImage image, int brightness) {
            Console.WriteLine("Image in color - OLED Screen + brightness: " + brightness);
        }
    }
}
