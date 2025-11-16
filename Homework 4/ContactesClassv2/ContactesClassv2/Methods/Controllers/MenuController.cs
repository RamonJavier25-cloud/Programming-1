using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactesClassv2.Methods.Services;

using ContactesClassv2.Methods.Helpers;


namespace ContactesClassv2.Methods.Controllers
{

    public class MenuController
    {
        private readonly ContactService _contactService;
        private bool _isRunning;

        public MenuController()
        {
            _contactService = new ContactService();
            _isRunning = true;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to my list of Contacts");
            Console.WriteLine();

            while (_isRunning)
            {
                DisplayMenu();
                ProcessOption();
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║         CONTACT MANAGEMENT MENU        ║");
            Console.WriteLine("╠════════════════════════════════════════╣");
            Console.WriteLine("║  1. Add Contact                        ║");
            Console.WriteLine("║  2. View Contacts                      ║");
            Console.WriteLine("║  3. Search Contacts                    ║");
            Console.WriteLine("║  4. Modify Contact                     ║");
            Console.WriteLine("║  5. Delete Contact                     ║");
            Console.WriteLine("║  6. Exit                               ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
        }

        private void ProcessOption()
        {
            try
            {
                int option = InputHelper.GetIntInput("Enter the number of the desired option:");
                Console.WriteLine();

                switch (option)
                {
                    case 1:
                        _contactService.AddContact();
                        break;
                    case 2:
                        _contactService.DisplayAllContacts();
                        break;
                    case 3:
                        _contactService.SearchContact();
                        break;
                    case 4:
                        _contactService.ModifyContact();
                        break;
                    case 5:
                        _contactService.DeleteContact();
                        break;
                    case 6:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

                if (_isRunning)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private void Exit()
        {
            _isRunning = false;
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("     Thank you for using the Contact Management System!       ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
        }
    }
}
