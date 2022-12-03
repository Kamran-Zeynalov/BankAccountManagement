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

        public bool? Registration(string name, string surname, string email, string password, bool isAdmin)
        {

            foreach (User mail in _userRepository.Bank.Users)
            {
                if (mail.Email == email)
                {
                    return false;
                }
            }
            User user = new User(name, surname, email, password, isAdmin);
            return true;
        }

        public bool FindUser(string email)
        {
            User exicted = null;
            foreach (User mail in _userRepository.Bank.Users)
            {
                if (mail.Email == email)
                {
                    exicted = mail;
                    return true;
                }
            }
     
            _userRepository.FindUser(exicted);
            return true;
        }

        bool FindEmailandPw(string email, string password)
        {
            foreach (User user in _userRepository.Bank.Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Login(string email, string password)
        {
            FindEmailandPw(email, password);
            if (FindEmailandPw(email, password) == true)
            {
            _userRepository.UserLogin(email, password);
            return true;
            }
             return false;
        }
    }
}

