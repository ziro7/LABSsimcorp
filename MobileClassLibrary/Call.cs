using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABSsimcorp {
    public class Call : IComparable {
        private int contactNumber;
        public Contact Contact { get; set; }
        public DateTime CallTime { get; set; }
        public bool IsIncommingCall { get; set; }

        public int ContactNumber
        {
            get { return contactNumber;}
            set {
                List<int> allowedNumbers = new List<int>() { Contact.MainPhoneNumber };
                foreach (int number in Contact.AdditionalPhoneNumbers) {
                    allowedNumbers.Add(number);
                }

                if (allowedNumbers.Contains(contactNumber)) {
                    contactNumber = value;
                } else {
                    Contact.AdditionalPhoneNumbers.Add(contactNumber);
                    contactNumber = value;
                }
            }
        }

        public Call(Contact contact, int phoneNumber, DateTime callTime, bool isIncomming) {
            Contact = contact;
            ContactNumber = phoneNumber;
            CallTime = callTime;
            IsIncommingCall = isIncomming;
        }

        public void AddIncommingCall(Contact contact, int contactNumber, DateTime callTime) {
            Contact = contact;
            ContactNumber = contactNumber;
            CallTime = callTime;
            IsIncommingCall = true;
        }

        public void AddOutgoingCall(Contact contact, int contactNumber, DateTime callTime) {
            Contact = contact;
            ContactNumber = contactNumber;
            CallTime = callTime;
            IsIncommingCall = false;
        }

        public int CompareTo(object obj) {
            Call compareCall = (Call)obj;
            if (this.CallTime > compareCall.CallTime) { return -1; }
            if (this.CallTime == compareCall.CallTime) { return 0; }
            return 1;
        }
    }
}
