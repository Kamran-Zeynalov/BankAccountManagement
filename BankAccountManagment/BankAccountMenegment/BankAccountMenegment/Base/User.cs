using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Base
{
    internal class User
    {
        public int Id;
        int _count;
        string _name;
        string _surName;
        string _email;
        double _balance;
        string _password;
        public bool IsAdmin;
        public bool IsBlocked;
        public bool IsLogged;

        public User()
        {
            _count = 1342;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length >= 3)
                {
                    _name = value;
                }
            }
        }
        public string SurName
        {
            get
            {
                return _surName;
            }
            set
            {
                if (value.Length >= 3)
                {
                    _surName = value;
                }
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (CheckEmail(value))
                {
                    _email = value;
                }
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (CheckPassword(value))
                {
                    _password = value;
                }
            }
        }

        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }

        public User(string name, string surName, string email, string password, bool isAdmin = false)
        {

            Name = name;
            SurName = surName;
            Email = email;
            Password = password;
            Id = ++_count;
            IsAdmin = false;
            IsBlocked = false;
            IsLogged = false;

        }


        static bool CheckEmail(string email)
        {
            if (email.Contains("@"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool CheckPassword(string password)
        {
            bool hasDigit = false;
            bool hasLower = false;
            bool hasUpper = false;
            bool result = false;

            foreach (char item in password)
            {

                if (char.IsDigit(item))
                {
                    hasDigit = true;
                }
                else if (char.IsLower(item))
                {
                    hasLower = true;
                }
                else if (char.IsUpper(item))
                {
                    hasUpper = true;
                }
                result = hasDigit && hasLower && hasUpper;
                if (result)
                {
                    break;
                }
            }
            return result;
        }

    }
}
