using BankAccountMenegment.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Repository
{
    internal interface IBankRepository
    {
        public Bank Bank { get; }
        void CheckBalance(User user);
        void TopUpBalance(User user);
        string ChangePassword(User user, string password2);
        void BankUserList();
        bool BlockUser(User user);
        bool LogOut(User user);

    }
}
