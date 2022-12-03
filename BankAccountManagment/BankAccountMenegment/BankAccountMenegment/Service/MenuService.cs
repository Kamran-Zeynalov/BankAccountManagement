using BankAccountMenegment.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Service
{
    internal class MenuService
    {
        readonly static BankService _bankService;
        readonly static UserService _userService;

        static MenuService()
        {
            _bankService = new BankService();
            _userService = new UserService();
        }


        #region User Registration
        public static void UserRegistrstion()
        {
            string name;
            string surname;
            string email;
            string password;
            bool isAdmin =false;
            string admin;

            do
            {
                Console.WriteLine("Create account:");
                Console.Write("Name: ");
                name = Console.ReadLine();
                Console.Write("Surname: ");
                surname = Console.ReadLine();
            }
            while (!NameandSurnameChecker(name, surname));

            do
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
            }
            while (!CheckEmail(email));

            do
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
            }
            while (!CheckPassword(password));

            admin = Console.ReadLine();

            if (admin.ToLower() == "y")
            {
                isAdmin = true;
            }
            else if (admin.ToLower() == "n")
            { 
            isAdmin= false; 
            }

            _userService.Registration(name, surname, email, password, isAdmin);
        }
        #endregion

        #region User Login
        public static void Login()
        {
            string email;
            string password; 

            do
            {
                Console.WriteLine("Enter your Email");
                email = Console.ReadLine();
                Console.WriteLine("Enter your password");
                password = Console.ReadLine();
            } while (!_userService.Login(email, password));
        }
        #endregion

        #region Find User
        public static void FindUser()
        {
            string email;
            do
            {
                email = Console.ReadLine();
            } while (!_userService.FindUser(email));
        }
        #endregion

        #region Change Password
        public static void ChanegePassword()
        {
            string password;
            string newPassword;

            do
            {
                password = Console.ReadLine();
                newPassword = Console.ReadLine();
                CheckPassword(newPassword);
            } while (!_bankService.ChangePassword(password, newPassword));
        }
        #endregion

        #region Check Balance
        public static void CheckBalance()
        {
            string password;
            do
            {
                password = Console.ReadLine();
            } while (!_bankService.CheckBalance(password));
        }

        #endregion

        #region Top Up Balance
        public static void TopUpBalance()
        {
            string password;
            double newBalance;
            do
            {
                password = Console.ReadLine();
                newBalance = Convert.ToInt32(Console.ReadLine());
            } while (!_bankService.TopUpBalance(password, newBalance));
        }
        #endregion

        public static void UserList()
        {
            string email;
            do
            {
                Console.WriteLine("All User List");
                email = Console.ReadLine();
            } while (!_bankService.UserList(email));
            
        }

        public static void BlockUser()
        { 
        UserList();
            string email ;
            do
            {
                Console.WriteLine("Do Block someone");
               email = Console.ReadLine();
            } while (!_bankService.BlockUser(email));
        }



        static bool CheckEmail(string mail)
        {
            if (mail.Contains('@') == true)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Use @ symbol");
            }
            return false;
        }
        static bool NameandSurnameChecker(string name, string surname)
        {
            if (name.Length >= 3 && surname.Length >= 3)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Use another Name and Surname");
            }
            return false;
        }
        static bool CheckPassword(string password)
        {
            bool hasDigit = false;
            bool hasLower = false;
            bool hasUpper = false;
            bool result = false;

            foreach (char item in password)
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
    }
}
