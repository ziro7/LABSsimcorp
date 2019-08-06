using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class Speakers : IPlayback,IBluetoothConnect {

        public bool UseingBluetooth { get; set; }

        public Speakers(bool useingBluetooth) {
            UseingBluetooth = useingBluetooth;
            if (UseingBluetooth) {
                Pairring();
            }
        }

        public void Pairring() {
            Console.WriteLine("Bluetooth connected");
        }

        public void Play() {
            Console.WriteLine("Plays on the " + typeof(Speakers));
        }
    }
}
