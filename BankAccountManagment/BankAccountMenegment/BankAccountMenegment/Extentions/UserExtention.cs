using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankAccountMenegment.Extentions
{
    public static class UserExtention
    {

        public static void CheckName(string value)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Name: ");
                Console.ForegroundColor = ConsoleColor.White;
                value = Console.ReadLine();
            } while (!CheckLength(value));
        }
        public static void CheckSurname(string value)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Surname: ");
                Console.ForegroundColor = ConsoleColor.White;
                value = Console.ReadLine();
            } while (!CheckLength(value));
        }
        public static void CheckEmail(string value)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Email: ");
                Console.ForegroundColor = ConsoleColor.White;
                value = Console.ReadLine();
            } while (!Checksymbol(value));
        }
        public static void CheckPassword(string value)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Password: ");
                Console.ForegroundColor = ConsoleColor.White;
                value = ReadPassword();
            } while (!CheckPass(value));
        }
        public static void IsAdmin(bool role, char result)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Is admin? y/n: ");
                Console.ForegroundColor = ConsoleColor.White;
                role = char.TryParse(Console.ReadLine(), out result);
            } while (!role);
        }



        #region Private Extentions

        static bool CheckLength(string value)
        {
            if (value.Length > 2)
            {
                return true;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Your Name and Surname must be at least 2 characters long.");
            return false;
        }
        static bool Checksymbol(string symbol)
        {
            if (symbol.Contains('@'))
            {
                return true;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Use @ symbol");
                return false;
            }
        }
        public static bool CheckPass(string pass)
        {
            bool hasDigit = false;
            bool hasLower = false;
            bool hasUpper = false;
            bool result = false;

            foreach (char item in pass)
            {


                if (char.IsDigit(item))
                {
                    hasDigit = true;
                }
                else if (char.IsLower(item))
                {
                    hasLower = true;
                }
                else if (char.IsUpper(item))
                {
                    hasUpper = true;
                }
                result = hasDigit && hasLower && hasUpper;
                if (result)
                {
                    break;
                }

            }
            return result;
        }
        private static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
                else if (keyInfo.Key != ConsoleKey.Enter)
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }

            } while (keyInfo.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return password;
        }

        #endregion




    }
}
