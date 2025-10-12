
    string answer = "";

    while (!(answer.Equals("yes", StringComparison.OrdinalIgnoreCase) || answer.Equals("no", StringComparison.OrdinalIgnoreCase)))
    {
        Console.WriteLine("Do you want to start the program? (Yes/No)");
        answer = Console.ReadLine()!;
    }

    while (answer.Equals("yes", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Enter a number:");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number % 2 == 0)
                Console.WriteLine($"{number} is even.");
            else
                Console.WriteLine($"{number} is odd.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }


        answer = "";
        while (!(answer.Equals("yes", StringComparison.OrdinalIgnoreCase) || answer.Equals("no", StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Do you want to check another number? (Yes/No)");
            answer = Console.ReadLine()!;
        }
    }
    Console.WriteLine("Program ended. Goodbye!");
