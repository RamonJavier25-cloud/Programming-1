using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactesClassv2.Methods.Helpers
{
   
    public static class InputHelper
    {
        public static int GetIntInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: You must enter a valid number. Please try again.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: The number entered is too large or too small.");
                }
            }
        }

        public static string GetStringInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        public static bool GetYesNoInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine()?.Trim().ToLower() ?? "";

                if (input == "yes" || input == "y" || input == "1")
                    return true;
                if (input == "no" || input == "n" || input == "2")
                    return false;

                Console.WriteLine("Invalid input. Please enter Yes/No or 1/2.");
            }
        }

        public static int GetValidAge(string prompt)
        {
            while (true)
            {
                try
                {
                    int age = GetIntInput(prompt);
                    if (age <= 0 || age > 120)
                    {
                        Console.WriteLine("Error: Age must be between 1 and 120.");
                        continue;
                    }
                    return age;
                }
                catch
                {
                    Console.WriteLine("Please enter the age again.");
                }
            }
        }
    }
    
}
