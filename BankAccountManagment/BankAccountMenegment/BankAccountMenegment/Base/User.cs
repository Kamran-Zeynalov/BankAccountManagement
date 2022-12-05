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
        protected string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 2)
                {
                    _name = value;
                }
            }
        }
        protected string _surname;
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (value.Length > 2)
                {
                    _surname = value;
                }
            }
        }
        string _password;
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

        public int Id;

        public bool IsAdmin;
        public bool IsBlocked;
        public bool IsLogged;
        public double Balance;
        static int count;

        protected string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (EmailChecker(value))
                {
                    _email = value;
                }
            }
        }




        static User()
        {
            count = 0;
        }

        public User(string name, string surname, string password, string email, bool isadmin)
        {
            Name = name;
            Surname = surname;
            Password = password;
            Email = email;
            IsBlocked = false;
            IsAdmin = isadmin;
            IsLogged = false;
            Balance = default;
            Id = ++count;


        }

        public static bool CheckPassword(string pw)
        {
            bool hasDigit = false;
            bool hasLower = false;
            bool hasUpper = false;
            bool result = false;

            foreach (char item in pw)
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

        public static bool EmailChecker(string symble)
        {
            if (symble.Contains('@'))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
