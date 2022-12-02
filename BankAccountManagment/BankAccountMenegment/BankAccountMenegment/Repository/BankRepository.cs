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
        public void BankUserList(User user)
        {
        }

        public void BlockUser(User user)
        {
            
        }

        public void ChangePassword(User user, string password2)
        {

        }

        public void CheckBalance(User user)
        {
            Console.WriteLine(user.Balance);
        }

        public void TopUpBalance(User user, double newBalance)
        {
            
        }

        static void UserAdmin(User user)
        {
            if (user.IsAdmin == true)
            { 
            
            }
        }
    }
}
