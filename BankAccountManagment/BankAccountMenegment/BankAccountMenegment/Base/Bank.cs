using BankAccountMenegment.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankAccountMenegment.Base
{
    internal class Bank
    {
        public int Id;
        public User[] Users; 
        int _count;
        public Bank(User[] user)
        {
            Users = new User[0];
            Id = ++_count;
        }
        public Bank()
        {
            _count = 1423;
        }

    }
}


