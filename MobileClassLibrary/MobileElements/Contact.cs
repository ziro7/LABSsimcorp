using System.Collections;
using System.Collections.Generic;

namespace LABSsimcorp {
    public class Contact : IEnumerable{

        public int ContactId { get; set; }
        public string Name { get; set; }
        public int MainPhoneNumber { get; set; }
        public List<int> AdditionalPhoneNumbers { get; set; }

        public Contact(int userId, string name, int phoneNumber, params int[] additonalNumbers) {
            ContactId = userId;
            Name = name;
            MainPhoneNumber = phoneNumber;
            AdditionalPhoneNumbers = new List<int>();
            foreach (int number in additonalNumbers) {
                AdditionalPhoneNumbers.Add(number);
            }
        }

        public IEnumerator GetEnumerator() {
            return ((IEnumerable)Name).GetEnumerator();
        }
    }
}
