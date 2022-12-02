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
        void TopUpBalance(User user, double newBalance);
        void ChangePassword(User user, string password2);
        void BankUserList(User user);
        void BlockUser(User user);

    }
}
