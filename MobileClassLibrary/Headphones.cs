namespace LABSsimcorp {
    public class Headphones : IPlayback {

        public IOutput Output { get; set; }

        public Headphones(IOutput output) {
            Output = output;
        }
        public void Play(object data) {
            Output.WriteLine("Plays on the " + typeof(Headphones));
        }
    }
}
