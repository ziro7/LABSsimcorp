using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    public class PhoneSpeaker : IPlayback {
        public IOutput Output { get; set; }

        public PhoneSpeaker(IOutput output) {
            Output = output;
        }
        public void Play(object data) {

            Output.WriteLine("Plays on the " + typeof(PhoneSpeaker));
        }
    }
}
