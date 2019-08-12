namespace LABSsimcorp {
    public abstract class ScreenBase {
        public double SizeInInches { get; set; }
        public int PixelCount { get; set; }
        public IOutput Output { get; set; }

        protected ScreenBase(double sizeInInches, int pixelCount, IOutput output) {
            SizeInInches = sizeInInches;
            PixelCount = pixelCount;
            Output = output;
        }

        public abstract void Show(IScreenImage image);
        public abstract void Show(IScreenImage image, int brightness);

    }
}