using System.Numerics;
using System.Xml.Linq;



Console.WriteLine("Welcome to my list of Contacts");

//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool running = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

// Variable para llevar el próximo ID disponible
int nextId = 1;

while (running)
{
    int typeOption = 0;
    Console.WriteLine("1. Add Contact\n2. View Contacts\n3. Search Contacts\n4. Modify Contact\n5. Delete Contact\n6. Exit");
    Console.WriteLine("Enter the number of the desired option");

    try
    {
        typeOption = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception ex)
    {
        HandleException(ex);
        continue;
    }

    switch (typeOption)
    {
        case 1:
            {
                try
                {
                    AddContact();
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        break;

        case 2:
            {
                try
                {
                    DisplayAllContacts();
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        break;

        case 3:
            {
                try
                {
                    FindContact();
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        break;

        case 4:
            {
                try
                {
                    ModifyContact();
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        break;

        case 5:
            {
                try
                {
                    DeleteContact();
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        break;

        case 6:
            running = false;
            Console.WriteLine("Thank you for using the contact agenda");
            break;
        default:
            Console.WriteLine("Invalid option, please try again");
        break;
    }
}

string IsBestFriend(bool addIsFriend)
{
    string isBestFriendStr = (addIsFriend == true) ? "Yes" : "No";
    return isBestFriendStr;
}

void AddContact()
{
    Console.Clear();
    Console.WriteLine("Enter the person's name");
    string name = Console.ReadLine();
    Console.WriteLine("Enter the person's last name");
    string lastname = Console.ReadLine();
    Console.WriteLine("Enter the address");
    string address = Console.ReadLine();

    // Validar teléfono único
    string phone;
    bool phoneExists;
    do
    {
        phoneExists = false;
        Console.WriteLine("Enter the person's phone number");
        phone = Console.ReadLine();

        // Verificar si el teléfono ya existe
        foreach (var existingPhone in telephones.Values)
        {
            if (existingPhone == phone)
            {
                Console.WriteLine("This phone number already exists. Please enter a different phone number.");
                phoneExists = true;
                break;
            }
        }
    } while (phoneExists);

    Console.WriteLine("Enter the person's email");
    string email = Console.ReadLine();

    int age = 0;
    bool validAge = false;
    while (!validAge)
    {
        Console.WriteLine("Enter the person's age in numbers");
        try
        {
            age = Convert.ToInt32(Console.ReadLine());
            if (age <= 0 || age > 120)
                throw new ArgumentOutOfRangeException();
            validAge = true;
        }
        catch (Exception ex)
        {
            HandleException(ex);
            Console.WriteLine("Please enter the age again.");
        }
    }

    bool isBestFriend = false;
    bool validBestFriendInput = false;
    while (!validBestFriendInput)
    {
        Console.WriteLine("Specify if it's a best friend: 1. Yes, 2. No");
        string bestFriendInput = Console.ReadLine();

        if (bestFriendInput == "1" || bestFriendInput.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
        {
            isBestFriend = true;
            validBestFriendInput = true;
        }
        else if (bestFriendInput == "2" || bestFriendInput.Equals("no", StringComparison.CurrentCultureIgnoreCase))
        {
            isBestFriend = false;
            validBestFriendInput = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter 1/Yes or 2/No.");
        }
    }

    // Validación de confirmación con while
    bool validConfirmation = false;
    while (!validConfirmation)
    {
        Console.WriteLine("Is the information correct? (Yes/No)");
        string confirm = Console.ReadLine();

        if (confirm.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine("Contact added successfully");
            ConfirmContacts(name, lastname, address, phone, email, age, isBestFriend);
            validConfirmation = true;
        }
        else if (confirm.Equals("No", StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine("Please enter the data again");
            AddContact();
            validConfirmation = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter only 'Yes' or 'No'.");
        }
    }
}

void ConfirmContacts(string name, string lastname, string address, string phone, string email, int age, bool isBestFriend)
{
    int id = nextId;
    nextId++;

    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);
}

void FindContact()
{
    Console.Clear();
    Console.WriteLine("Search by: 1. Name, 2. Phone Number, 3. ID");
    string searchOption = Console.ReadLine();

    if (searchOption == "2")
    {
        Console.WriteLine("Enter the phone number to search for:");
        string searchPhone = Console.ReadLine();

        bool found = false;
        foreach (var pair in telephones)
        {
            if (pair.Value == searchPhone)
            {
                found = true;
                int id = pair.Key;
                var isBestFriend = bestFriends[id];
                string isBestFriendStr = IsBestFriend(isBestFriend);

                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                Console.WriteLine("                      CONTACT INFORMATION                      ");
                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                Console.WriteLine($"ID: {id}");
                Console.WriteLine($"Name: {names[id]}");
                Console.WriteLine($"Last Name: {lastnames[id]}");
                Console.WriteLine($"Address: {addresses[id]}");
                Console.WriteLine($"Phone: {telephones[id]}");
                Console.WriteLine($"Email: {emails[id]}");
                Console.WriteLine($"Age: {ages[id]}");
                Console.WriteLine($"Best Friend: {isBestFriendStr}");
                Console.WriteLine("───────────────────────────────────────────────────────────────");
                Console.WriteLine();
                break; // Solo un resultado ya que el teléfono es único
            }
        }

        if (!found)
        {
            Console.WriteLine("No results found");
        }
    }
    else if (searchOption == "3")
    {
        Console.WriteLine("Enter the ID to search for:");
        try
        {
            int searchId = Convert.ToInt32(Console.ReadLine());

            if (ids.Contains(searchId))
            {
                var isBestFriend = bestFriends[searchId];
                string isBestFriendStr = IsBestFriend(isBestFriend);

                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                Console.WriteLine("                      CONTACT INFORMATION                      ");
                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                Console.WriteLine($"ID: {searchId}");
                Console.WriteLine($"Name: {names[searchId]}");
                Console.WriteLine($"Last Name: {lastnames[searchId]}");
                Console.WriteLine($"Address: {addresses[searchId]}");
                Console.WriteLine($"Phone: {telephones[searchId]}");
                Console.WriteLine($"Email: {emails[searchId]}");
                Console.WriteLine($"Age: {ages[searchId]}");
                Console.WriteLine($"Best Friend: {isBestFriendStr}");
                Console.WriteLine("───────────────────────────────────────────────────────────────");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No contact found with that ID.");
            }
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }
    else
    {
        // Búsqueda por nombre (código original)
        Console.WriteLine("Enter the name of the person to search for");
        string searchName = Console.ReadLine();

        bool found = false;
        foreach (var id in ids)
        {
            if (names[id].ToLower().Contains(searchName.ToLower()))
            {
                found = true;
                var isBestFriend = bestFriends[id];
                string isBestFriendStr = IsBestFriend(isBestFriend);

                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                Console.WriteLine("                      CONTACT INFORMATION                      ");
                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                Console.WriteLine($"ID: {id}");
                Console.WriteLine($"Name: {names[id]}");
                Console.WriteLine($"Last Name: {lastnames[id]}");
                Console.WriteLine($"Address: {addresses[id]}");
                Console.WriteLine($"Phone: {telephones[id]}");
                Console.WriteLine($"Email: {emails[id]}");
                Console.WriteLine($"Age: {ages[id]}");
                Console.WriteLine($"Best Friend: {isBestFriendStr}");
                Console.WriteLine("───────────────────────────────────────────────────────────────");
                Console.WriteLine();
            }
        }

        if (!found)
        {
            Console.WriteLine("No results found");
        }
    }
}

void DeleteContact()
{
    Console.Clear();

    // Primero mostrar todos los contactos para que el usuario vea los IDs
    DisplayAllContacts();

    if (ids.Count == 0)
    {
        return; // No hay contactos para eliminar
    }

    Console.WriteLine("Enter the ID of the contact to delete:");
    try
    {
        int deleteId = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(deleteId))
        {
            Console.WriteLine("No contact found with that ID.");
            return;
        }

        // Mostrar información del contacto antes de eliminar
        var isBestFriend = bestFriends[deleteId];
        string isBestFriendStr = IsBestFriend(isBestFriend);

        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("               CONTACT TO DELETE - CONFIRMATION               ");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine($"ID: {deleteId}");
        Console.WriteLine($"Name: {names[deleteId]}");
        Console.WriteLine($"Last Name: {lastnames[deleteId]}");
        Console.WriteLine($"Address: {addresses[deleteId]}");
        Console.WriteLine($"Phone: {telephones[deleteId]}");
        Console.WriteLine($"Email: {emails[deleteId]}");
        Console.WriteLine($"Age: {ages[deleteId]}");
        Console.WriteLine($"Best Friend: {isBestFriendStr}");
        Console.WriteLine("───────────────────────────────────────────────────────────────");

        // Validación de confirmación con while
        bool validConfirmation = false;
        while (!validConfirmation)
        {
            Console.WriteLine("Are you sure you want to delete this contact? (Yes/No)");
            string confirm = Console.ReadLine();

            if (confirm.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
            {
                // Eliminar el contacto de todas las colecciones
                ids.Remove(deleteId);
                names.Remove(deleteId);
                lastnames.Remove(deleteId);
                addresses.Remove(deleteId);
                telephones.Remove(deleteId);
                emails.Remove(deleteId);
                ages.Remove(deleteId);
                bestFriends.Remove(deleteId);

                Console.WriteLine("Contact deleted successfully");
                validConfirmation = true;
            }
            else if (confirm.Equals("No", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Deletion cancelled");
                validConfirmation = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter only 'Yes' or 'No'.");
            }
        }
    }
    catch (Exception ex)
    {
        HandleException(ex);
    }
}

void ModifyContact()
{
    Console.Clear();

    // Primero mostrar todos los contactos para que el usuario vea los IDs
    DisplayAllContacts();

    if (ids.Count == 0)
    {
        return; // No hay contactos para modificar
    }

    Console.WriteLine("Enter the ID of the contact to modify:");
    try
    {
        int modifyId = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(modifyId))
        {
            Console.WriteLine("No contact found with that ID.");
            return;
        }

        // Mostrar información actual
        Console.WriteLine("Current contact information:");
        var currentIsBestFriend = bestFriends[modifyId];
        string currentIsBestFriendStr = IsBestFriend(currentIsBestFriend);

        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("                    CURRENT INFORMATION                       ");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine($"Name: {names[modifyId]}");
        Console.WriteLine($"Last Name: {lastnames[modifyId]}");
        Console.WriteLine($"Address: {addresses[modifyId]}");
        Console.WriteLine($"Phone: {telephones[modifyId]}");
        Console.WriteLine($"Email: {emails[modifyId]}");
        Console.WriteLine($"Age: {ages[modifyId]}");
        Console.WriteLine($"Best Friend: {currentIsBestFriendStr}");
        Console.WriteLine("───────────────────────────────────────────────────────────────");

        Console.WriteLine("Enter the new name of the person");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the new last name of the person");
        string lastname = Console.ReadLine();
        Console.WriteLine("Enter the new address");
        string address = Console.ReadLine();

        // Validar nuevo teléfono único
        string phone;
        bool phoneExists;
        do
        {
            phoneExists = false;
            Console.WriteLine("Enter the new phone number of the person");
            phone = Console.ReadLine();

            // Verificar si el teléfono ya existe (excluyendo el contacto actual)
            foreach (var pair in telephones)
            {
                if (pair.Key != modifyId && pair.Value == phone)
                {
                    Console.WriteLine("This phone number already exists in another contact. Please enter a different phone number.");
                    phoneExists = true;
                    break;
                }
            }
        } while (phoneExists);

        Console.WriteLine("Enter the new email of the person");
        string email = Console.ReadLine();

        int age = 0;
        bool validAge = false;
        while (!validAge)
        {
            Console.WriteLine("Enter the new age of the person in numbers");
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
                if (age <= 0 || age > 120)
                    throw new ArgumentOutOfRangeException();
                validAge = true;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                Console.WriteLine("Please enter the age again.");
            }
        }

        bool isBestFriend = false;
        bool validBestFriendInput = false;
        while (!validBestFriendInput)
        {
            Console.WriteLine("Specify if it's a best friend: 1. Yes, 2. No");
            string bestFriendInput = Console.ReadLine();

            if (bestFriendInput == "1" || bestFriendInput.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
            {
                isBestFriend = true;
                validBestFriendInput = true;
            }
            else if (bestFriendInput == "2" || bestFriendInput.Equals("no", StringComparison.CurrentCultureIgnoreCase))
            {
                isBestFriend = false;
                validBestFriendInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 1/Yes or 2/No.");
            }
        }

        // Validación de confirmación con while
        bool validConfirmation = false;
        while (!validConfirmation)
        {
            Console.WriteLine("Are you sure you want to save these changes? (Yes/No)");
            string confirm = Console.ReadLine();

            if (confirm.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
            {
                names[modifyId] = name;
                lastnames[modifyId] = lastname;
                addresses[modifyId] = address;
                telephones[modifyId] = phone;
                emails[modifyId] = email;
                ages[modifyId] = age;
                bestFriends[modifyId] = isBestFriend;
                Console.WriteLine("Contact modified successfully");
                validConfirmation = true;
            }
            else if (confirm.Equals("No", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Modification cancelled");
                validConfirmation = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter only 'Yes' or 'No'.");
            }
        }
    }
    catch (Exception ex)
    {
        HandleException(ex);
    }
}

void DisplayAllContacts()
{
    Console.Clear();
    if (ids.Count == 0)
    {
        Console.WriteLine("No contacts available.");
        return;
    }

    // Ordenar los IDs para mostrarlos en orden
    var sortedIds = ids.OrderBy(id => id).ToList();

    foreach (var id in sortedIds)
    {
        var isBestFriend = bestFriends[id];
        string isBestFriendStr = IsBestFriend(isBestFriend);

        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("                      CONTACT INFORMATION                     ");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Name: {names[id]}");
        Console.WriteLine($"Last Name: {lastnames[id]}");
        Console.WriteLine($"Address: {addresses[id]}");
        Console.WriteLine($"Phone: {telephones[id]}");
        Console.WriteLine($"Email: {emails[id]}");
        Console.WriteLine($"Age: {ages[id]}");
        Console.WriteLine($"Best Friend: {isBestFriendStr}");
        Console.WriteLine("───────────────────────────────────────────────────────────────");
        Console.WriteLine();
    }
}

void HandleException(Exception ex)
{
    if (ex is FormatException)
    {
        Console.WriteLine("Error: You must enter a valid number. Please try again.");
    }
    else if (ex is OverflowException)
    {
        Console.WriteLine("Error: The number entered is too large or too small.");
    }
    else if (ex is ArgumentNullException)
    {
        Console.WriteLine("Error: You cannot leave the field empty.");
    }
    else if (ex is KeyNotFoundException)
    {
        Console.WriteLine("Error: The contact does not exist in the list.");
    }
    else if (ex is InvalidOperationException)
    {
        Console.WriteLine("Error: The requested operation is not valid at this time.");
    }
    else if (ex is IndexOutOfRangeException)
    {
        Console.WriteLine("Error: Index out of range. Please check the entered data.");
    }
    else if (ex is ArgumentOutOfRangeException)
    {
        Console.WriteLine("Error: Age must be between 1 and 120.");
    }
    else
    {
        Console.WriteLine($"Unexpected error: {ex.Message}");
    }
}