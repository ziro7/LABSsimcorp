using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    public abstract class ScreenBase {
        public double SizeInInches { get; set; }
        public int PixelCount { get; set; }

        protected ScreenBase(double sizeInInches, int pixelCount) {
            SizeInInches = sizeInInches;
            PixelCount = pixelCount;
        }

        public abstract void Show(IScreenImage image);

    }
}