using BankAccountMenegment.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Repository
{
    internal class BankRepository : IBankRepositories
    {
        Bank _bank;
        public Bank bank
        {
            get
            {
                return _bank;
            }
        }

        public BankRepository(Bank bank)
        {
            _bank = bank;
        }
        public void BankUserList()
        {
            foreach (User user in _bank.users)
            {
                Console.WriteLine(user.Name, user.Surname);
            }
        }

        public bool BlockUser(User user)
        {
            return user.IsBlocked = true;
        }

        public string ChangePassword(User user, string newPassword)
        {
            Console.WriteLine("Password Changed");
            user.Password = newPassword;
            return user.Password;
        }

        public void CheckBalance(User user)
        {
            Console.WriteLine(user.Balance);
        }

        public void ToUpBalance(User user, double amount)
        {
            user.Balance += amount;
            Console.WriteLine($"New Balance: {user.Balance}");
        }

        public bool LogOut(User user)
        {
            return user.IsLogged = false;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
