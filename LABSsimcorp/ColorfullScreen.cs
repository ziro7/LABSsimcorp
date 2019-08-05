﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class ColorfullScreen : ScreenBase {

        public ColorfullScreen(double sizeInInches, int pixelCount) 
            :base(sizeInInches,pixelCount) {

        }
        public override void Show(IScreenImage image) {
            Console.WriteLine("Image in color - Colorfull Screen");
        }

        public override void Show(IScreenImage image, int brightness) {
            Console.WriteLine("Image in color - Colorfull Screen + brightness: " + brightness);
        }

        public override string ToString() => nameof(ColorfullScreen);
    }
}