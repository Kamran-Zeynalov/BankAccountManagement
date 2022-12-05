using BankAccountMenegment.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Repository
{
    internal interface IBankRepositories
    {
        void BankUserList();
        bool BlockUser(User user);
        string ChangePassword(User user, string newPassword);
        void CheckBalance(User user);
        void ToUpBalance(User user, double amount);
        bool LogOut(User user);

    }
}
