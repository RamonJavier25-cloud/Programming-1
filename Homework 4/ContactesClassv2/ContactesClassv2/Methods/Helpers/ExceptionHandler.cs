using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactesClassv2.Methods.Helpers
{
   
    public static class ExceptionHandler
    {
        public static void Handle(Exception ex)
        {
            switch (ex)
            {
                case FormatException:
                    Console.WriteLine("Error: You must enter a valid number. Please try again.");
                    break;
                case OverflowException:
                    Console.WriteLine("Error: The number entered is too large or too small.");
                    break;
                case ArgumentNullException:
                    Console.WriteLine("Error: You cannot leave the field empty.");
                    break;
                case KeyNotFoundException:
                    Console.WriteLine("Error: The contact does not exist in the list.");
                    break;
                case InvalidOperationException:
                    Console.WriteLine("Error: The requested operation is not valid at this time.");
                    break;
                case IndexOutOfRangeException:
                    Console.WriteLine("Error: Index out of range. Please check the entered data.");
                    break;
                case ArgumentOutOfRangeException:
                    Console.WriteLine("Error: Age must be between 1 and 120.");
                    break;
                default:
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                    break;
            }
        }
    }
    
}
