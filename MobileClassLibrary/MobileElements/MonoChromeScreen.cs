namespace LABSsimcorp {
    public class MonoChromeScreen : ScreenBase {

        public MonoChromeScreen(double sizeInInches, int pixelCount, IOutput output) 
            :base(sizeInInches,pixelCount, output) {

        }

        public override void Show(IScreenImage image) {
            Output.WriteLine("Drawing a drawing on MonoChromeScreen - Black and White");
        }

        public override void Show(IScreenImage image, int brightness) {
            Output.WriteLine("Drawing a drawing on MonoChromeScreen - Black and White + brightness: " + brightness);
        }

        public override string ToString() => nameof(MonoChromeScreen);
    }
}
