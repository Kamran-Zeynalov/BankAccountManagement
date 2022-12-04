using BankAccountMenegment.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Repository
{
    internal interface IAccountRepository
    {
        public Bank Bank { get; }

        void UserRegist( User user);
        void UserLogin( User user);
        void FindUser( User user); 
    }
}
