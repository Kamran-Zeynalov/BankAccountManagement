using BankAccountMenegment.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Repository
{
    internal class UserRepository : IUserRepositories
    {
        private Bank _bank;

        public Bank bank
        {
            get
            {
                return _bank;
            }
        }

        public UserRepository(Bank bank)
        {
            _bank = bank;
        }

        public void UserRegistration(User user)
        {

            Array.Resize(ref _bank.users, _bank.users.Length + 1);

            _bank.users[_bank.users.Length - 1] = user;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You have successfully registered");
            Thread.Sleep(1000);
        }

        public void UserLogin(User user)
        {
            user.IsLogged = true;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"User:{user.Name} {user.Surname}");
            Thread.Sleep(1000);
        }

        public void FindUser(User user)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"User: {user.Name} {user.Surname}");
            Thread.Sleep(1000);
        }
    }
}
