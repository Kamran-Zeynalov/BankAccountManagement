using BankAccountMenegment.Base;
using BankAccountMenegment.Extentions;
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Registration");
            Console.ForegroundColor = ConsoleColor.Green;
            UserExtention.CheckName(out string name);
            UserExtention.CheckSurname(out string surname);
            UserExtention.CheckEmail(out string email);
            UserExtention.CheckPassword(out string password);
            UserExtention.IsAdmin(out bool role, out char result);

            if (result.ToString().ToLower() == 'y'.ToString())
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Login");
            Console.ForegroundColor = ConsoleColor.Green;
            string email;
            string password;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Email: ");
                Console.ForegroundColor = ConsoleColor.White;
                email = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Password: ");
                Console.ForegroundColor = ConsoleColor.White;
                password = UserExtention.ReadPassword();
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
                UserExtention.CheckPass(newpassword);

            } while (!_bankservices.ChangePassword(password, newpassword));

        }






        public static void CheckBalans()
        {
            string password;
            string balance;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter password to view balance");
            Console.ForegroundColor = ConsoleColor.White;
            password = UserExtention.ReadPassword();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Balance: ");

            if (_bankservices.CheckBalance(password))
            {
                Console.Write("Loading");
                Thread.Sleep(500);
                Console.Write(" . ");
                Thread.Sleep(500);
                Console.Write(" . ");
                Thread.Sleep(500);
                Console.Write(" . ");
            }
          
        }

        public static void TopUpBalance()
        {
            string password;
            double newBalance;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter password to top up balance:");
                Console.ForegroundColor = ConsoleColor.White;
                password = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("How much you want to increase");
                Console.ForegroundColor = ConsoleColor.White;
                newBalance = Convert.ToDouble(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
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
                Console.Write("admin's email: ");
                Console.ForegroundColor = ConsoleColor.White;
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
                Console.Write("Enter the email you want to block: ");
                Console.ForegroundColor = ConsoleColor.White;
                email = Console.ReadLine();
            } while (!_bankservices.BlockUser(email));
        }

       
        public static void Logout()
        {
            MenuService.ProgramService();
        }

        public static void ProgramService()
        {
            char UserServiceSelect;
            selection:
            do
            {
            Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Registration");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Find User");
                Console.WriteLine("0. Exit");
                UserServiceSelect = Console.ReadKey().KeyChar;
                Console.Clear();
              
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
                    case '0':
                        Console.Write("Thank you for choosing us :) ");
                        Thread.Sleep(500);
                        Console.Write(" . ");
                        Thread.Sleep(500);
                        Console.Write(" . ");
                        Thread.Sleep(500);
                        Console.Write(" . ");
                        Thread.Sleep(500);
                        Console.Clear();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please choose correct number");
                        Thread.Sleep(1000);
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
