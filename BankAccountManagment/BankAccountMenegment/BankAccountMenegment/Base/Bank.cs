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
        public User[] Users = new User[0]; 
        static int _count;
        public Bank()
        {
            Id = ++_count;
        }
        static Bank()
        {
            _count = 1423;
        }

    }
}


