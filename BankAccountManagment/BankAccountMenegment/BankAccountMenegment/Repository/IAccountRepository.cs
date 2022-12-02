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

        void UserRegist( string name, string surName, string email, string password);
        bool UserLogin( string email, string password);
        void FindUser( User user); 

    }
}
