using BankAccountMenegment.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Service
{

    internal static class MenuService
    {
        readonly static BankService _bankservices;

        readonly static UserService _accountservice;

        static Bank myBank;

        static MenuService()
        {

            myBank = new Bank();

            _bankservices = new BankService(myBank);

            _accountservice = new UserService(myBank);

        }
        public static void Registration()
        {

            string name;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Name:");
                name = Console.ReadLine();
            } while (!NameChecker(name));

            string surname;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Surname:");
                surname = Console.ReadLine();
            } while (!SurnameChecker(surname));


            string email;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Email:");
                email = Console.ReadLine();

            } while (!EmailChecker(email));

            string password;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Password:");
                password = Console.ReadLine();

            } while (!CheckPassword(password));

            bool isadmin;
            char yesOrNo;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Is admin? y/n");
                isadmin = char.TryParse(Console.ReadLine(), out yesOrNo);
            } while (!isadmin);


            if (yesOrNo.ToString().ToLower() == 'y'.ToString())
            {
                _accountservice.UserRegistration(name, surname, password, email, true);
            }
            else
            {
                _accountservice.UserRegistration(name, surname, password, email, false);
            }
        }
        public static bool Login()
        {

            string email;
            string password;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Email:");
                email = Console.ReadLine();
                Console.WriteLine("Password:");
                password = Console.ReadLine();
            } while (_accountservice.UserLogin(email, password));

            return true;
        }

        public static bool FindUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string email;
            Console.WriteLine("Enter the email address of the person you are looking for");
            email = Console.ReadLine();
            if (_accountservice.FindUser(email))
            {
                return true;
            }
            return false;
        }

        public static void ChangePassword()
        {
            string password;
            string newpassword;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Past Password");
                password = Console.ReadLine();
                Console.WriteLine("New Password");
                newpassword = Console.ReadLine();
                CheckPassword(newpassword);

            } while (!_bankservices.ChangePassword(password, newpassword));

        }
        public static void CheckBalans()
        {
            string password;
            string balance;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter password to view balance");
            password = Console.ReadLine();
            Console.WriteLine("    Balance:");

            if (_bankservices.CheckBalance(password))
            {
                Console.Write("Loading");
                Thread.Sleep(1000);
                Console.Write("  .");
                Thread.Sleep(1000);
                Console.Write("  .");
                Thread.Sleep(1000);
                Console.Write("  .");
            }
          
        }

        public static void TopUpBalance()
        {
            string password;
            double newBalance;
       
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter password to top up balance");
                password = Console.ReadLine();
                Console.WriteLine("How much you want to increase");
                newBalance = Convert.ToDouble(Console.ReadLine());

            if (_bankservices.TopUpBalance(password, newBalance))
            {
                Console.Write("Loading");
                Thread.Sleep(1000);
                Console.Write("  .");
                Thread.Sleep(1000);
                Console.Write("  .");
                Thread.Sleep(1000);
                Console.Write("  .");
            }
        }
        public static void UserList()
        {
            string email;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("admin's email");
                email = Console.ReadLine();


            } while (!_bankservices.BankUserList(email));

        }
        public static void BlockUser()
        {
            UserList();
            string email;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter the slant you want to block");
                email = Console.ReadLine();
            } while (!_bankservices.BlockUser(email));
        }
        static bool NameChecker(string name)
        {
            if (name.Length > 2)
            {
                return true;
            }
            return false;
        }


        static bool SurnameChecker(string surname)
        {
            if (surname.Length > 2)
            {
                return true;
            }

            return false;
        }
        static bool CheckPassword(string pass)
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
        static bool EmailChecker(string symbol)
        {
            if (symbol.Contains('@'))
            {
                return true;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("use @ symbol");
                return false;
            }
        }
        public static void Logout()
        {
            MenuService.ProgramService();
        }

        public static void ProgramService()
        {

            char UserServiceSelect;
            Console.ForegroundColor = ConsoleColor.Green;
            do
            {
                Console.WriteLine("1. Registration");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Find User");
                Console.WriteLine("0. Exit");
            selection:
                UserServiceSelect = Console.ReadKey().KeyChar;
                Console.Clear();
                Console.WriteLine();
                switch (UserServiceSelect)
                {
                    case '1':
                        MenuService.Registration();
                        Console.Clear();
                        break;
                    case '2':
                        MenuService.Login();
                        Console.Clear();
                        break;
                    case '3':
                        MenuService.FindUser();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Please choose correct number");
                        Console.Clear();
                        goto selection;
                }
            } while (UserServiceSelect != '0');
        }

        public static void AllServicess()
        {

            char BankServiceSelect;
            Console.ForegroundColor = ConsoleColor.Green;

            do
            {
                Console.WriteLine("1. Check balance");
                Console.WriteLine("2. Top up balance");
                Console.WriteLine("3. Change password");
                Console.WriteLine("4. Bank user list");
                Console.WriteLine("5. Block user");
                Console.WriteLine("6. Logout");
            selection1:
                BankServiceSelect = Console.ReadKey().KeyChar;
                Console.Clear();
                Console.WriteLine();
                switch (BankServiceSelect)
                {
                    case '1':
                        MenuService.CheckBalans();
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case '2':
                        MenuService.TopUpBalance();
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case '3':
                        MenuService.ChangePassword();
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case '4':
                        MenuService.UserList();
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case '5':
                        MenuService.BlockUser();
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case '6':
                        MenuService.Logout();
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Please choose correct number");
                        Thread.Sleep(1000);
                        Console.Clear();
                        goto selection1;
                }
            } while (BankServiceSelect != '0');
        }
    }
}
