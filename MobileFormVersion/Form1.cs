using System;
using System.Windows.Forms;
using LABSsimcorp;

namespace MobileFormVersion {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, EventArgs e) {

            var output = new LabelOutput(OutputLabel);
            var mobilePhone = new MobilePhone(Model.Iphone10, output);
            output.WriteLine(mobilePhone.GetDescription());

            var choice = -1;

            if (HeadPhonesRadioButton.Checked) { choice = 1; }
            if (SpeakersRadioButton.Checked) { choice = 2; }
            if (PhoneSpeakerRadioButton.Checked) { choice = 3; }

            IPlayback audioDevice = null;
            if (choice == -1) { return; }

            if (choice == 1) {
                audioDevice = new Headphones(output);
            } else if (choice == 2) {
                audioDevice = new Speakers(false, output);
            } else if (choice == 3) {
                audioDevice = new PhoneSpeaker(output);
            } else {
                output.Write("No Valid channel selected");
            }

            if (audioDevice != null) {
                mobilePhone.InsertEquipmentInJackStick(audioDevice);
                mobilePhone.AudioInJackStik.Play(new object());
            }
        }
    }
}
