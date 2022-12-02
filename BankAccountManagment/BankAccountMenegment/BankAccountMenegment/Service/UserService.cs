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

        public bool? Registration(string name, string surname, string email, string password, bool isadmin)
        {

            foreach (User mail in _userRepository.Bank.Users)
            {
                if (mail.Email == email)
                {

                    return false;
                }
            }
            User user = new User(name, surname, email, password, isadmin);
            return true;

        }

        public bool FindUser(string email, string password)
        {
            User exicted = default;
            foreach (User mail in _userRepository.Bank.Users)
            {
                if (mail.Email == email)
                {
                    exicted = mail;
                }
            }
             
            if (exicted == null)
            {
                return false;
            }
            _userRepository.FindUser(exicted);
            return true;
        }
        bool FindEmailandPass(string email, string password)
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
            FindEmailandPass(email, password);
            if (FindEmailandPass(email, password) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            _userRepository.UserLogin(email, password);
            return true;
        }
    }

}
}
