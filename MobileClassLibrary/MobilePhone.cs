using System.Text;

namespace LABSsimcorp {
    public class MobilePhone {
        public Battery Battery { get; set; }
        public Keyboard Keyboard { get; set; }
        public MicroPhone MicroPhone { get; set; }
        public ScreenBase Screen { get; set; }
        public IPlayback AudioInJackStik { get; set; }
        public IOutput Output { get; set; }
        public SMSProvider SMSProviderInstance { get; set; }

        public MobilePhone(Model model, IOutput outputChannel) {
            Output = outputChannel;
            SMSProviderInstance = new SMSProvider();
            AttachSMSRecievedHandler();
            switch (model) {
                case Model.IPhone6:
                    Battery = new Battery(100);
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new MonoChromeScreen(5, 100, outputChannel);
                    break;
                case Model.Iphone7:
                    Battery = new Battery(120);
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new ColorfullScreen(5.3, 120, outputChannel);
                    break;
                case Model.Iphone8:
                    Battery = new Battery(150);
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new OLEDScreen(5.5, 150, outputChannel);
                    break;
                case Model.Iphone10:
                    Battery = new Battery(200);
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new RetinaScreen(6, 200, outputChannel);
                    break;
                case Model.SamsungGalaxy10:
                    Battery = new Battery(200);
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new RetinaScreen(6.5, 250, outputChannel);
                    break;
                default:
                    Output.WriteLine("No such screen");
                    break;
            }
        }

        private void AttachSMSRecievedHandler() {
            SMSProviderInstance.OnSMSReceived += SMSReceivedHandler;
        }

        public void SMSReceivedHandler(string message) {
            string formattedMessage = Formatter(message);
            Output.WriteLine(formattedMessage);
        }

        public void ChangeFormat (FormatDelegate formatDelegate) {
            Formatter = formatDelegate;
        }

        public void Show(IScreenImage image) {
            Screen.Show(image);
        }

        public void Show(IScreenImage image, int brightness) {
            Screen.Show(image,brightness);
        }

        public void InsertEquipmentInJackStick(IPlayback playDevice) {
            AudioInJackStik = playDevice;
        }

        public void Play(object data) {
            AudioInJackStik.Play(data);
        }

        public string GetDescription() {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Screen type: {Screen.ToString()}");
            return descriptionBuilder.ToString();
        }

        public delegate string FormatDelegate(string text);

        private FormatDelegate Formatter = OutputFormat.FormatToUpper;

    }
}
