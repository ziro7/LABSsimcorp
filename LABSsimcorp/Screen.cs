using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
        public class Screen {
            public double SizeInInches { get; set; }
            public int PixelCount { get; set; }

            public Screen(double sizeInInches, int pixelCount) {
                SizeInInches = sizeInInches;
                PixelCount = pixelCount;
            }
        }
    }