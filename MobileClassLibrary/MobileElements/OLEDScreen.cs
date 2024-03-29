﻿namespace LABSsimcorp {
    public class OLEDScreen : ColorfullScreen{

        public OLEDScreen(double sizeInInches, int pixelCount, IOutput output) 
            :base(sizeInInches,pixelCount, output) {

        }
        public override void Show(IScreenImage image) {
            Output.WriteLine("Image in color - OLED Screen");
        }

        public override void Show(IScreenImage image, int brightness) {
            Output.WriteLine("Image in color - OLED Screen + brightness: " + brightness);
        }
        public override string ToString() => nameof(OLEDScreen);
    }
}
