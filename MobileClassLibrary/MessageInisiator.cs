using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace LABSsimcorp {
    public abstract class MessageInisiator {

        public System.Timers.Timer myTimer;
        public MobilePhone PhoneToMessage { get; set; }

        protected MessageInisiator(MobilePhone phoneToMessage, int intervalBetweenTicks = 1000) {
            PhoneToMessage = phoneToMessage;
            myTimer = new System.Timers.Timer {
                Interval = intervalBetweenTicks,
                Enabled = false
            };
            AttachOnElapsedEventHandler();
        }
        private void AttachOnElapsedEventHandler() {
            myTimer.Elapsed += OnElapsedHandler;
        }

        public void GenerateMessages() {

            if (myTimer != null) {
                myTimer.Enabled = true;
                myTimer.Start();
            }
        }

        public void StopMessages() {
            if (myTimer != null) {
                myTimer.Enabled = false;
                myTimer.Close();
            }
        }

        public void OnElapsedHandler(object sender, EventArgs e) {
            var message = GenerateRandomMessage();
            OnSMSReceived?.Invoke(this, new MessageEventArgs(message));
        }

        private Message GenerateRandomMessage() {
            var random = new Random();
            int userInt = random.Next(0, PhoneToMessage.ContactList.Count);

            string message = string.Format("SMS received at: {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());

            return new Message(PhoneToMessage.ContactList[userInt], message, DateTime.Now);
        }

        public abstract void StartService();
        public abstract void StopService();

        public static event EventHandler<MessageEventArgs> OnSMSReceived;
    }
}
