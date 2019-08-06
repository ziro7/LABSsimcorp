using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class Program {
        static void Main(string[] args) {

            var mobilePhone = new MobilePhone(Model.Iphone10);
            Console.WriteLine(mobilePhone.GetDescription());

            Console.WriteLine("Select playback component attached in Jack Stick.");
            Console.WriteLine("1 - Headphones");
            Console.WriteLine("2 - Speakers");
            Console.WriteLine("3 - PhoneSpeakers");
            var choice = System.Convert.ToInt32(Console.ReadLine());

            IPlayback audioDevice;
            if (choice == 1) {
                audioDevice = new Headphones();
            } else if (choice == 2) {
                audioDevice = new Speakers(false);
            } else {
                audioDevice = new PhoneSpeaker();
            }

            mobilePhone.InsertEquipmentInJackStick(audioDevice);
            mobilePhone.AudioInJackStik.Play(new object());

            Console.ReadLine();
        }
    }
}
