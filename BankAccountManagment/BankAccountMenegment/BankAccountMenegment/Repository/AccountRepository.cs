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

        public void UserRegist(string name, string surName, string email, string password)
        {
            User user = new User(name, surName, email, password);
            Array.Resize(ref _bank.Users, _bank.Users.Length+ 1);
            _bank.Users[_bank.Users.Length - 1] = user;
        }

        public bool UserLogin(string email, string password)
        {
            foreach (User us in _bank.Users)
            {
                if (us.Email == email && us.Password == password)
                {
                    us.IsLogged = true;
                    return us.IsLogged;
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
