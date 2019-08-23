using System.Collections.Generic;

namespace LABSsimcorp {
    public class Contact {

        public int ContactId { get; set; }
        public string Name { get; set; }
        public int MainPhoneNumber { get; set; }
        public List<int> AdditionalPhoneNumbers { get; set; }

        public Contact(int userId, string name, int phoneNumber, params int[] homePhoneNumber) {
            ContactId = userId;
            Name = name;
            MainPhoneNumber = phoneNumber;
            AdditionalPhoneNumbers = new List<int>();
            foreach (int number in homePhoneNumber) {
                AdditionalPhoneNumbers.Add(number);
            }
        }
    }
}
