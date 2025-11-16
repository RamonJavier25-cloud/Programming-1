using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactesClassv2.Methods.Repositories;
using ContactesClassv2.ContactAgenda.Models;
using ContactesClassv2.Methods.Helpers;



namespace ContactesClassv2.Methods.Services
{
    public class ContactService
    {
        private readonly ContactRepository _repository;

        public ContactService()
        {
            _repository = new ContactRepository();
        }

        public void AddContact()
        {
         
        
            Console.Clear();
            try
            {
                string name;
                do
                {
                    name = InputHelper.GetStringInput("Enter the person's name:");
                    if (!ValidationService.ValidateName(name))
                        Console.WriteLine("Invalid name. Only letters and spaces allowed, minimum 2 characters.");
                    else
                        break;
                } while (true);

                string lastName;
                do
                {
                    lastName = InputHelper.GetStringInput("Enter the person's last name:");
                    if (!ValidationService.ValidateName(lastName))
                        Console.WriteLine("Invalid last name.");
                    else
                        break;
                } while (true);

                string address;
                do
                {
                    address = InputHelper.GetStringInput("Enter the address:");
                    if (!ValidationService.ValidateAddress(address))
                        Console.WriteLine("Invalid address. Must be at least 5 characters.");
                    else
                        break;
                } while (true);

                string phone;
                do
                {
                    phone = InputHelper.GetStringInput("Enter the person's phone number:");
                    if (!ValidationService.ValidatePhone(phone))
                    {
                        Console.WriteLine("Invalid phone number format.");
                        continue;
                    }

                    if (_repository.PhoneExists(phone))
                    {
                        Console.WriteLine("This phone number already exists. Please enter a different one.");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                string email;
                do
                {
                    email = InputHelper.GetStringInput("Enter the person's email:");
                    if (!ValidationService.ValidateEmail(email))
                        Console.WriteLine("Invalid email format. Please try again.");
                    else
                        break;
                } while (true);

                int age;
                do
                {
                    age = InputHelper.GetValidAge("Enter the person's age in numbers:");
                    if (!ValidationService.ValidateAge(age))
                        Console.WriteLine("Invalid age. Must be between 1 and 120.");
                    else
                        break;
                } while (true);

                bool isBestFriend = InputHelper.GetYesNoInput("Specify if it's a best friend (Yes/No or 1/2):");

                var contact = new Contact(0, name, lastName, address, phone, email, age, isBestFriend);

                if (InputHelper.GetYesNoInput("Is the information correct? (Yes/No)"))
                {
                    _repository.Add(contact);
                    Console.WriteLine("Contact added successfully!");
                }
                else
                {
                    Console.WriteLine("Contact not added.");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }
        



        public void DisplayAllContacts()
        {
            Console.Clear();
            var contacts = _repository.GetAll();

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts available.");
                return;
            }

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void SearchContact()
        {
            Console.Clear();
            Console.WriteLine("Search by: 1. Name, 2. Phone Number, 3. ID");
            string searchOption = InputHelper.GetStringInput("Enter option:");

            try
            {
                switch (searchOption)
                {
                    case "1":
                        SearchByName();
                        break;
                    case "2":
                        SearchByPhone();
                        break;
                    case "3":
                        SearchById();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private void SearchByName()
        {
            string searchName = InputHelper.GetStringInput("Enter the name to search for:");
            var results = _repository.SearchByName(searchName);

            if (results.Count == 0)
            {
                Console.WriteLine("No results found.");
            }
            else
            {
                foreach (var contact in results)
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }

        private void SearchByPhone()
        {
            string searchPhone = InputHelper.GetStringInput("Enter the phone number to search for:");
            var contact = _repository.SearchByPhone(searchPhone);

            if (contact == null)
            {
                Console.WriteLine("No results found.");
            }
            else
            {
                Console.WriteLine(contact.ToString());
            }
        }

        private void SearchById()
        {
            int searchId = InputHelper.GetIntInput("Enter the ID to search for:");
            var contact = _repository.GetById(searchId);

            if (contact == null)
            {
                Console.WriteLine("No contact found with that ID.");
            }
            else
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void ModifyContact()
        {
            Console.Clear();
            DisplayAllContacts();

            if (_repository.Count() == 0)
            {
                return;
            }

            try
            {
                int modifyId = InputHelper.GetIntInput("Enter the ID of the contact to modify:");
                var existingContact = _repository.GetById(modifyId);

                if (existingContact == null)
                {
                    Console.WriteLine("No contact found with that ID.");
                    return;
                }

                Console.WriteLine("Current contact information:");
                Console.WriteLine(existingContact.ToString());

                string name;
                do
                {
                    name = InputHelper.GetStringInput("Enter the person's name:");
                    if (!ValidationService.ValidateName(name))
                        Console.WriteLine("Invalid name. Only letters and spaces allowed, minimum 2 characters.");
                    else
                        break;
                } while (true);

                string lastName;
                do
                {
                    lastName = InputHelper.GetStringInput("Enter the person's last name:");
                    if (!ValidationService.ValidateName(lastName))
                        Console.WriteLine("Invalid last name.");
                    else
                        break;
                } while (true);

                string address;
                do
                {
                    address = InputHelper.GetStringInput("Enter the address:");
                    if (!ValidationService.ValidateAddress(address))
                        Console.WriteLine("Invalid address. Must be at least 5 characters.");
                    else
                        break;
                } while (true);

                string phone;
                do
                {
                    phone = InputHelper.GetStringInput("Enter the person's phone number:");
                    if (!ValidationService.ValidatePhone(phone))
                    {
                        Console.WriteLine("Invalid phone number format.");
                        continue;
                    }

                    if (_repository.PhoneExists(phone))
                    {
                        Console.WriteLine("This phone number already exists. Please enter a different one.");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                string email;
                do
                {
                    email = InputHelper.GetStringInput("Enter the person's email:");
                    if (!ValidationService.ValidateEmail(email))
                        Console.WriteLine("Invalid email format. Please try again.");
                    else
                        break;
                } while (true);

                int age;
                do
                {
                    age = InputHelper.GetValidAge("Enter the person's age in numbers:");
                    if (!ValidationService.ValidateAge(age))
                        Console.WriteLine("Invalid age. Must be between 1 and 120.");
                    else
                        break;
                } while (true);

                bool isBestFriend = InputHelper.GetYesNoInput("Specify if it's a best friend (Yes/No or 1/2):");

                var contact = new Contact(0, name, lastName, address, phone, email, age, isBestFriend);

                if (InputHelper.GetYesNoInput("Is the information correct? (Yes/No)"))
                {
                    _repository.Add(contact);
                    Console.WriteLine("Contact added successfully!");
                }
                else
                {
                    Console.WriteLine("Contact not added.");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        public void DeleteContact()
        {
            Console.Clear();
            DisplayAllContacts();

            if (_repository.Count() == 0)
            {
                return;
            }

            try
            {
                int deleteId = InputHelper.GetIntInput("Enter the ID of the contact to delete:");
                var contact = _repository.GetById(deleteId);

                if (contact == null)
                {
                    Console.WriteLine("No contact found with that ID.");
                    return;
                }

                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                Console.WriteLine("               CONTACT TO DELETE - CONFIRMATION               ");
                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                Console.WriteLine(contact.ToString());

                if (InputHelper.GetYesNoInput("Are you sure you want to delete this contact? (Yes/No)"))
                {
                    _repository.Remove(deleteId);
                    Console.WriteLine("Contact deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Deletion cancelled.");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }
    }
}
