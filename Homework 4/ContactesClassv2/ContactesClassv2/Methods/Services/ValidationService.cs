using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactesClassv2.Methods.Services
{
    public static class ValidationService
    {
        public static bool ValidateAge(int age)
        {
            return age > 0 && age <= 120;
        }

        public static bool ValidateNonEmpty(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            // Solo letras y espacios
            return name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)) && name.Length >= 2;
        }

        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            // Trim espacios
            email = email.Trim();

            // Debe contener exactamente un @
            int atCount = email.Count(c => c == '@');
            if (atCount != 1)
            {
                return false;
            }

            // Encontrar la posición del @
            int atIndex = email.IndexOf('@');

            // El @ no puede estar al principio ni al final
            if (atIndex < 1 || atIndex >= email.Length - 1)
            {
                return false;
            }

            // Separar en usuario y dominio
            string username = email.Substring(0, atIndex);
            string domain = email.Substring(atIndex + 1);

            // El dominio debe contener al menos un punto
            if (!domain.Contains("."))
            {
                return false;
            }

            // El punto no puede estar al principio ni al final del dominio
            if (domain.StartsWith(".") || domain.EndsWith("."))
            {
                return false;
            }

            // Debe haber al menos un carácter después del último punto
            int lastDotIndex = domain.LastIndexOf('.');
            if (lastDotIndex == domain.Length - 1 || lastDotIndex < 0)
            {
                return false;
            }

            // El dominio después del último punto debe tener al menos 2 caracteres
            string tld = domain.Substring(lastDotIndex + 1);
            if (tld.Length < 2)
            {
                return false;
            }

            // Validar con MailAddress como segunda capa
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Solo números, guiones y paréntesis, mínimo 7 caracteres
            string cleanPhone = phone.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
            return cleanPhone.All(char.IsDigit) && cleanPhone.Length >= 7 && cleanPhone.Length <= 15;
        }

        public static bool ValidateAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return false;

            // Mínimo 5 caracteres para una dirección válida
            return address.Length >= 5;
        }

        public static bool ValidatePositiveNumber(int number)
        {
            return number > 0;
        }

        public static bool ValidateId(int id)
        {
            return id > 0;
        }

        public static bool ValidateStringLength(string input, int minLength, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return input.Length >= minLength && input.Length <= maxLength;
        }

        public static bool ValidateNoSpecialCharacters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            // Solo letras, números y espacios
            return input.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c));
        }

        public static bool ValidateAlphanumeric(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return input.All(char.IsLetterOrDigit);
        }

        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Eliminar espacios al inicio y final, y múltiples espacios
            return string.Join(" ", input.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        public static bool ValidateRange(int value, int min, int max)
        {
            return value >= min && value <= max;
        }
    }

}
