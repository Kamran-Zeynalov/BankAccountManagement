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
        public Bank Bank { get => _bank;}
        public AccountRepository()
        {
            _bank = new Bank();
        }

        public void UserRegist(User user)
        {
            Array.Resize(ref Bank.Users, Bank.Users.Length+ 1);
            Bank.Users[Bank.Users.Length - 1] = user;
            Console.WriteLine("You are registered");
            Thread.Sleep(1000);
            user.Balance = 0;
        }

        public void UserLogin(User user)
        {
            user.IsLogged = true;
            Console.WriteLine($"{user.Name}, {user.SurName}");
            Thread.Sleep(1000);

        }

        public void FindUser(User user)
        {
            Console.WriteLine($"User: {user.Name}, Surname: {user.SurName}");
            Thread.Sleep(1000);
        }
    }
}
