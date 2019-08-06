using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class MobilePhone {
        public Battery Battery { get; set; }
        public Keyboard Keyboard { get; set; }
        public MicroPhone MicroPhone { get; set; }
        public ScreenBase Screen { get; set; }
        public IPlayback AudioInJackStik { get; set; }

        public MobilePhone(Model model) {
            switch (model) {
                case Model.IPhone6:
                    Battery = new Battery(100);
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new MonoChromeScreen(5, 100);
                    break;
                case Model.Iphone7:
                    Battery = new Battery(120);
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new ColorfullScreen(5.3, 120);
                    break;
                case Model.Iphone8:
                    Battery = new Battery(150);
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new OLEDScreen(5.5, 150);
                    break;
                case Model.Iphone10:
                    Battery = new Battery(200);
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new RetinaScreen(6, 200);
                    break;
                case Model.SamsungGalaxy10:
                    Battery = new Battery(200);
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new RetinaScreen(6.5, 250);
                    break;
                default:
                    Console.WriteLine("No such screen");
                    break;
            }
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

    }
}
