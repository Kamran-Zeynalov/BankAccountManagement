using BankAccountMenegment.Base;
using BankAccountMenegment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Service
{
    internal class UserService
    {
        readonly IAccountRepository _userRepository;

        public UserService()
        {
            _userRepository = new AccountRepository();
        }

        public bool Registration(string name, string surname, string email, string password, bool isAdmin)
        {

            foreach (User mail in _userRepository.Bank.Users)
            {
                if (mail.Email == email)
                {
                    Console.WriteLine(" This account was registered");
                    Thread.Sleep(1000);
                    Console.Clear();
                    MenuService.UserRegistrstion();
                    return false;
                }
            }
            User user = new(name, surname, email, password, isAdmin);
            _userRepository.UserRegist(user);
            return true;
        }

        public bool FindUser(string email)
        {
            User exicted;
            foreach (User mail in _userRepository.Bank.Users)
            {
                if (mail.Email == email)
                {
                    exicted = mail;
                    _userRepository.FindUser(exicted);
                    return true;
                   // Thread.Sleep(1000);
                }
            }
            Console.WriteLine("User wasn't Found");
            return false;

        }

        public bool Login(string email, string password)
        {
            foreach (User user in _userRepository.Bank.Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    _userRepository.UserLogin(user);
                    return true;
                }
            }
            Console.WriteLine("Result Not Found");
            return false;
            MenuService.Login();
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}

