using System;
using System.Collections.Generic;

namespace LABSsimcorp {
    internal class SMSProvider {

        public SMSProvider() {
            AttachOnSMSReceivedEventHandler();
        }

        private void AttachOnSMSReceivedEventHandler() {
            MessageInisiator.OnSMSReceived += SMSReceivedHandler;
        }

        public void SMSReceivedHandler (object sender, MessageEventArgs e) {
            OnSMSProcessed?.Invoke(this, e);
        }

        public static event EventHandler<MessageEventArgs> OnSMSProcessed;
    }
}
