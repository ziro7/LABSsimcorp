namespace LABSsimcorp {
    public class Speakers : IPlayback,IBluetoothConnect {

        public bool UseingBluetooth { get; set; }
        public IOutput Output { get; set; }

        public Speakers(bool useingBluetooth, IOutput output) {
            UseingBluetooth = useingBluetooth;
            Output = output;
            if (UseingBluetooth) {
                Pairring();
            }
        }

        public void Pairring() {
            Output.WriteLine("Bluetooth connected");
        }

        public void Play(object data) {
            Output.WriteLine("Plays on the " + typeof(Speakers));
        }
    }
}
