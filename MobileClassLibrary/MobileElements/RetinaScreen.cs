namespace LABSsimcorp {
    public class RetinaScreen : ColorfullScreen {

        public RetinaScreen(double sizeInInches, int pixelCount, IOutput output) 
            :base(sizeInInches,pixelCount, output) {

        }
        public override void Show(IScreenImage image) {
            Output.WriteLine("Image in color - Retina Screen");
        }
        public override void Show(IScreenImage image, int brightness) {
            Output.WriteLine("Image in color - Retina Screen + brightness: " + brightness);
        }

        public override string ToString() => nameof(RetinaScreen);
    }
}
