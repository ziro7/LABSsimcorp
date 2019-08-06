using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class ColorfullScreen : ScreenBase {

        public ColorfullScreen(double sizeInInches, int pixelCount, IOutput output) 
            :base(sizeInInches,pixelCount, output) {

        }
        public override void Show(IScreenImage image) {
            Output.WriteLine("Image in color - Colorfull Screen");
        }

        public override void Show(IScreenImage image, int brightness) {
            Output.WriteLine("Image in color - Colorfull Screen + brightness: " + brightness);
        }

        public override string ToString() => nameof(ColorfullScreen);
    }
}
