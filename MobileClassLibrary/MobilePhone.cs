using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using LabsSimcorp;

namespace LABSsimcorp {
    public class MobilePhone {
        public IBattery Battery { get; set; }
        public Keyboard Keyboard { get; set; }
        public MicroPhone MicroPhone { get; set; }
        public ScreenBase Screen { get; set; }
        public IPlayback AudioInJackStik { get; set; }
        public IOutput Output { get; set; }
        public List<Contact> ContactList { get; set; }
        internal SMSProvider SMSProviderInstance { get; set; }
        public ISMSStorage Messages;

        public MobilePhone(Model model, IOutput outputChannel, ISMSStorage smsStorage) {
            ImportingOldContacts();
            Output = outputChannel;
            Messages = smsStorage;
            SMSProviderInstance = new SMSProvider();
            //Battery = new ThreadBattery(100);
            //Battery = new TaskBattery(100);
            IBatteryFactory batteryFactory = LoadBattery(); //Loader den factory der er sat i settings - Pt. findes der kun 1.
            Battery = batteryFactory.CreateTaskBattery(); //Her vælges om man vælger den ene eller anden form for battery.

            switch (model) {
                case Model.IPhone6:
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new MonoChromeScreen(5, 100, outputChannel);
                    break;
                case Model.Iphone7:
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new ColorfullScreen(5.3, 120, outputChannel);
                    break;
                case Model.Iphone8:
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new OLEDScreen(5.5, 150, outputChannel);
                    break;
                case Model.Iphone10:
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new RetinaScreen(6, 200, outputChannel);
                    break;
                case Model.SamsungGalaxy10:
                    Keyboard = new Keyboard(false);
                    MicroPhone = new MicroPhone();
                    Screen = new RetinaScreen(6.5, 250, outputChannel);
                    break;
                default:
                    Output.WriteLine("No such screen");
                    break;
            }
        }

        private static IBatteryFactory LoadBattery() {
            string factornyName = DelegateMessageForm.Properties.Settings.Default.BatteryFactory;
            return Assembly.GetExecutingAssembly().CreateInstance(factornyName) as IBatteryFactory;
        }

        private void ImportingOldContacts() {
            ContactList = new List<Contact>();
            ContactList.Add(new Contact(1, "Jacob", 12341234));
            ContactList.Add(new Contact(2, "Jens", 12341235));
            ContactList.Add(new Contact(3, "Lennert", 12341236));
            ContactList.Add(new Contact(4, "Anne", 12341237));
            ContactList.Add(new Contact(5, "Sofie", 12341238));
            ContactList.Add(new Contact(6, "Gurli", 12341239));
        }

        public void AddContact(Contact user) {
            ContactList.Add(user);
        }

        public void ViewMessages(Dictionary<FilterCheckBox, bool> filterDictionary, FilterValueDTO filterValueDTO) {

            List<Message> filteredMessages = FilterMessages(filterDictionary, filterValueDTO);
            Output.WriteLine(filteredMessages, Formatter);
        }

        private List<Message> FilterMessages(Dictionary<FilterCheckBox, bool> filterDictionary, FilterValueDTO filterValueDTO) {

            var filteredMessages = Messages.MessagesList;

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
