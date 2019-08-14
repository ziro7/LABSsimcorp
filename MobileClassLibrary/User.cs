namespace LABSsimcorpy {
    public class User {

        public int UserId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }

        public User(int userId, string name, int phoneNumber) {
            UserId = userId;
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
