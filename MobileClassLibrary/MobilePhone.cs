using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LABSsimcorpy;

namespace LABSsimcorp {
    public class MobilePhone {
        public Battery Battery { get; set; }
        public Keyboard Keyboard { get; set; }
        public MicroPhone MicroPhone { get; set; }
        public ScreenBase Screen { get; set; }
        public IPlayback AudioInJackStik { get; set; }
        public IOutput Output { get; set; }
        public List<User> ContactList { get; set; }
        public SMSProvider SMSProviderInstance { get; set; }
        public List<Message> messages { get; set; }

        public MobilePhone(Model model, IOutput outputChannel) {
            ImportingOldContacts();
            Output = outputChannel;
            SMSProviderInstance = new SMSProvider(ContactList);
            messages = new List<Message>();
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

        private void ImportingOldContacts() {
            ContactList = new List<User>();
            ContactList.Add(new User(1, "Jacob", 12341234));
            ContactList.Add(new User(2, "Jens", 12341235));
            ContactList.Add(new User(3, "Lennert", 12341236));
            ContactList.Add(new User(4, "Anne", 12341237));
            ContactList.Add(new User(5, "Sofie", 12341238));
            ContactList.Add(new User(6, "Gurli", 12341239));
        }

        public void AddContact(User user) {
            ContactList.Add(user);
            SMSProviderInstance.ContactList.Add(user);
        }

        private void AttachSMSRecievedHandler() {
            SMSProviderInstance.OnSMSReceived += SMSReceivedHandler;
        }

        public void SMSReceivedHandler(Object sender, MessageEventArgs e) {
            messages.Add(e.Message);
        }

        public void ViewMessages(Dictionary<FilterCheckBox, bool> filterDictionary, FilterValueDTO filterValueDTO) {

            List<Message> filteredMessages = FilterMessages(filterDictionary, filterValueDTO);
            Output.WriteLine(filteredMessages, Formatter);
        }

        private List<Message> FilterMessages(Dictionary<FilterCheckBox, bool> filterDictionary, FilterValueDTO filterValueDTO) {

            var filteredMessages = messages;

            if (filterDictionary[FilterCheckBox.User]) {
                filteredMessages = filteredMessages
                                                    .Where(m => m.User.Name == filterValueDTO.UserName)
                                                    .ToList();
            }

            if (filterDictionary[FilterCheckBox.Message]) {
                filteredMessages = filteredMessages
                                                    .Where(m => m.Text.Contains(filterValueDTO.MessageSearchText))
                                                    .ToList();
            }

            if (filterDictionary[FilterCheckBox.Date]) {
                filteredMessages = filteredMessages
                                                    .Where(m => m.ReceivingTime >= filterValueDTO.FromDate)
                                                    .Where(m => m.ReceivingTime <= filterValueDTO.ToDate)
                                                    .ToList();
            }
           

            return filteredMessages;
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
