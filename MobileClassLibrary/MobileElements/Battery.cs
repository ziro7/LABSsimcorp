namespace LABSsimcorp {
    public class Battery {

        public double Size { get; set; }
        public bool IsCharging { get; set; }    

        public Battery(double size) {
            Size = size;
        }
    }
}
