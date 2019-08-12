using System;

namespace LABSsimcorp {
    class Program {
        static void Main(string[] args) {

            var output = new ConsoleOutput();
            var mobilePhone = new MobilePhone(Model.Iphone10, output);
            output.WriteLine(mobilePhone.GetDescription());
     
            output.WriteLine("Select playback component attached in Jack Stick.");
            output.WriteLine("1 - Headphones");
            output.WriteLine("2 - Speakers");
            output.WriteLine("3 - PhoneSpeakers");

            var choice = System.Convert.ToInt32(Console.ReadLine());

            IPlayback audioDevice;
            if (choice == 1) {
                audioDevice = new Headphones(output);
            } else if (choice == 2) {
                audioDevice = new Speakers(false, output);
            } else {
                audioDevice = new PhoneSpeaker(output);
            }

            mobilePhone.InsertEquipmentInJackStick(audioDevice);
            mobilePhone.AudioInJackStik.Play(new object());

            Console.ReadLine();
        }
    }
}
