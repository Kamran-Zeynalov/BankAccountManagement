using BankAccountMenegment.Base;
using BankAccountMenegment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Service
{
    internal class UserService
    {
        readonly IUserRepositories _repository;
        Bank bank;
        public UserService(Bank bank)
        {
            this.bank = bank;
            _repository = new UserRepository(this.bank);
        }

        public bool UserRegistration(string name, string surname, string email, string password, bool isAdmin)
        {
            foreach (User gmail in bank.users)
            {
                if (gmail.Email == email)
                {
                    Console.WriteLine("This email had been registered ");
                    Thread.Sleep(2000);
                    Console.Clear();
                    MenuService.Registration();
                    return false;
                }
            }
            User user = new User(name, surname, email, password, isAdmin);
            _repository.UserRegistration(user);
            return true;

        }

        public bool UserLogin(string email, string password)
        {
            foreach (User item in bank.users)
            {
                if (item.Email == email && item.Password == password)
                {
                    _repository.UserLogin(item);

                    MenuService.AllServicess();
                    return true;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Email or password is incorrect");
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(2000);
            return false;

        }


        public bool FindUser(string email)
        {
            User exicted = default;
            foreach (User gmail in bank.users)
            {
                if (gmail.Email == email)
                {
                    exicted = gmail;
                    _repository.FindUser(exicted);
                    return false;
                }
            }
            if (exicted == null)
            {
                Console.WriteLine("--This email is not registered--");
                return false;
            }
            Console.WriteLine("Not Found");
            _repository.FindUser(exicted);
            return false;
        }
        //bool EmailPassFind(string email, string password)
        //{
        //    foreach (User user in bank.users)
        //    {
        //        if (user.Email == email && user.Password == password)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

    }
}


