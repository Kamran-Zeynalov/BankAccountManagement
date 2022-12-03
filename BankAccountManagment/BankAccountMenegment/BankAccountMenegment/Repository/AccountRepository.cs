using BankAccountMenegment.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Repository
{
    internal class AccountRepository : IAccountRepository
    {
        Bank _bank;
        public Bank Bank { get => _bank; }
        public AccountRepository()
        {
            _bank = new Bank();
        }

        public void UserRegist(string name, string surName, string email, string password, bool isAdmin)
        {
            User user = new User(name, surName, email, password);
            Array.Resize(ref _bank.Users, _bank.Users.Length+ 1);
            _bank.Users[_bank.Users.Length - 1] = user;
        }

        public bool UserLogin(string email, string password)
        {
            foreach (User user1 in _bank.Users)
            {
                if (user1.Email == email && user1.Password == password)
                {
                    user1.IsLogged = true;
                    return user1.IsLogged;
                }
            }
            return false;
        }

        public void FindUser(User user)
        {
           
            if (user is not null)
            {
                foreach (User users in _bank.Users)
                {
                    Console.WriteLine(users);
                }
            }
            else
            {

                Console.WriteLine("There is no User!");
            }
        }
    }
}
