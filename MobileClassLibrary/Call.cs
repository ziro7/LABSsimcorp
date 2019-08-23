using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABSsimcorp {
    public class Call : IComparable {
        private int contactNumber;
        public Contact Contact { get; set; }
        public DateTime CallTime { get; set; }
        public List<Call> AssociatedCalls { get; set; }
        public int ContactNumber
        {
            get { return contactNumber;}
            set {
                List<int> allowedNumbers = new List<int>() { Contact.MainPhoneNumber };
                foreach (int number in Contact.AdditionalPhoneNumbers) {
                    allowedNumbers.Add(number);
                }
                if (!allowedNumbers.Contains(value)) {
                    Contact.AdditionalPhoneNumbers.Add(value);
                } 
                contactNumber = value;
            }
        }

        public Call(Contact contact, int phoneNumber, DateTime callTime) {
            Contact = contact;
            ContactNumber = phoneNumber;
            CallTime = callTime;
            AssociatedCalls = new List<Call>();
        }


        public int CompareTo(object obj) {
            Call compareCall = (Call)obj;
            if (this.CallTime > compareCall.CallTime) { return -1; }
            if (this.CallTime == compareCall.CallTime) { return 0; }
            return 1;
        }

        public override bool Equals(Object obj) {

            // Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) {
                return false;
            }
            // Same type so I can cast it.
            Call otherCall = (Call)obj;
            
            // If the contact is different they are not the same.
            if (!this.Contact.Equals(otherCall.Contact)) {
                return false;
            }

            // If the number is not the same is it not the same
            if (!this.ContactNumber.Equals(otherCall.ContactNumber)) {
                return false;
            }

            // If all that is the same - they must be equal
            return true;
        }

        // Just have to make sure these end up in same bucket when useing hash table
        public override int GetHashCode() {
            return this.Contact.GetHashCode() ^ this.Contact.GetHashCode();
        }

        public static bool operator == (Call x, Call y) {
            return object.Equals(x, y);
        }

        public static bool operator != (Call x, Call y) {
            return !object.Equals(x, y);
        }

        public static bool operator <(Call x, Call y) {
            if (x.CompareTo(y) < 0) {
                return true;
            } else {
                return false;
            }
        }

        public static bool operator >(Call x, Call y) {
            if (x.CompareTo(y) > 0) {
                return true;
            } else {
                return false;
            }
        }

        public static bool operator <=(Call x, Call y) {
            if (x.CompareTo(y) <= 0) {
                return true;
            } else {
                return false;
            }
        }

        public static bool operator >=(Call x, Call y) {
            if (x.CompareTo(y) >= 0) {
                return true;
            } else {
                return false;
            }
        }
    }
}
