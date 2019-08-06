using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class Headphones : IPlayback {

        public IOutput Output { get; set; }

        public Headphones(IOutput output) {
            Output = output;
        }
        public void Play(object data) {
            Output.WriteLine("Plays on the " + typeof(Headphones));
        }
    }
}
