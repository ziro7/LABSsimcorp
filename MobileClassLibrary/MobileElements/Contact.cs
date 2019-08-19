namespace LABSsimcorp {
    public class Contact {

        public int ContactId { get; set; }
        public string Name { get; set; }
        public int WorkPhoneNumber { get; set; }
        public int HomePhoneNumber { get; set; } //default 0 if not set in constructor

        public Contact(int userId, string name, int phoneNumber, int homePhoneNumber = 0) {
            ContactId = userId;
            Name = name;
            WorkPhoneNumber = phoneNumber;
        }
    }
}
