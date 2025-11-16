using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactesClassv2.ContactAgenda.Models
{
    public class Contact
    {
        
        private int _id;
        private string _name;
        private string _lastName;
        private string _address;
        private string _phone;
        private string _email;
        private int _age;
        private bool _isBestFriend;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public bool IsBestFriend
        {
            get { return _isBestFriend; }
            set { _isBestFriend = value; }
        }

        public Contact()
        {
        }

        public Contact(int id, string name, string lastName, string address,
                      string phone, string email, int age, bool isBestFriend)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Email = email;
            Age = age;
            IsBestFriend = isBestFriend;
        }

        public string GetFullName()
        {
            return $"{Name} {LastName}";
        }

        public string GetBestFriendStatus()
        {
            return IsBestFriend ? "Yes" : "No";
        }

        public override string ToString()
        {
            return $"═══════════════════════════════════════════════════════════════\n" +
                   $"                      CONTACT INFORMATION                      \n" +
                   $"═══════════════════════════════════════════════════════════════\n" +
                   $"ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Last Name: {LastName}\n" +
                   $"Address: {Address}\n" +
                   $"Phone: {Phone}\n" +
                   $"Email: {Email}\n" +
                   $"Age: {Age}\n" +
                   $"Best Friend: {GetBestFriendStatus()}\n" +
                   $"───────────────────────────────────────────────────────────────\n";
        }
    }
}
