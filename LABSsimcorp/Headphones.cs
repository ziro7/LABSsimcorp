using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class Headphones : IPlayback {
        public void Play(object data) {
            Console.WriteLine("Plays on the " + typeof(Headphones));
        }
    }
}
