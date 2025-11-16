using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactesClassv2.ContactAgenda.Models;

namespace ContactesClassv2.Methods.Repositories
{

        public class ContactRepository
        {
            private List<Contact> _contacts;
            private int _nextId;

            public ContactRepository()
            {
                _contacts = new List<Contact>();
                _nextId = 1;
            }

            public void Add(Contact contact)
            {
                contact.Id = _nextId++;
                _contacts.Add(contact);
            }

            public bool Remove(int id)
            {
                var contact = GetById(id);
                if (contact != null)
                {
                    _contacts.Remove(contact);
                    return true;
                }
                return false;
            }

            public bool Update(Contact updatedContact)
            {
                var existingContact = GetById(updatedContact.Id);
                if (existingContact != null)
                {
                    existingContact.Name = updatedContact.Name;
                    existingContact.LastName = updatedContact.LastName;
                    existingContact.Address = updatedContact.Address;
                    existingContact.Phone = updatedContact.Phone;
                    existingContact.Email = updatedContact.Email;
                    existingContact.Age = updatedContact.Age;
                    existingContact.IsBestFriend = updatedContact.IsBestFriend;
                    return true;
                }
                return false;
            }

            public Contact GetById(int id)
            {
                return _contacts.FirstOrDefault(c => c.Id == id);
            }

            public List<Contact> GetAll()
            {
                return _contacts.OrderBy(c => c.Id).ToList();
            }

            public List<Contact> SearchByName(string name)
            {
                return _contacts
                    .Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            public Contact SearchByPhone(string phone)
            {
                return _contacts.FirstOrDefault(c => c.Phone == phone);
            }

            public bool PhoneExists(string phone, int? excludeId = null)
            {
                return _contacts.Any(c => c.Phone == phone && c.Id != excludeId);
            }

            public int Count()
            {
                return _contacts.Count;
            }
        }
    
}
