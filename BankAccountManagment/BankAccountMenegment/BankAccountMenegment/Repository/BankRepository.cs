using BankAccountMenegment.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Repository
{
    internal class BankRepository : IBankRepository
    {
        Bank _bank;
        public Bank Bank { get => _bank; }
        public BankRepository()
        {
            _bank = new Bank();
        }
        public void BankUserList()
        {
            foreach (User user in _bank.Users)
            {
                Console.WriteLine(user.Name, user.SurName);
            }
        }

        public bool BlockUser(User user)
        {
            return user.IsBlocked = true; 
        }

        public string ChangePassword(User user, string password2)
        {
            user.Password = password2;
            return user.Password;
        }

        public void CheckBalance(User user)
        {
            Console.WriteLine(user.Balance);
        }

        public void TopUpBalance(User user)
        {
            Console.WriteLine(user.Balance);
        }

        public bool LogOut(User user)
        {
            return user.IsLogged = false;
        }
    }
}
