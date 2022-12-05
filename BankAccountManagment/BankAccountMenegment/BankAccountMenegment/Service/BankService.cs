using BankAccountMenegment.Base;
using BankAccountMenegment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMenegment.Service
{
    internal class BankService
    {

        readonly IBankRepositories _repository;
        Bank bank;
        public BankService(Bank bank)
        {
            this.bank = bank;
            _repository = new BankRepository(this.bank);
        }

        public BankService()
        {
        }


        public bool CheckBalance(string password)
        {

            foreach (User item in bank.users)
            {
                if (item.Password == password)
                {
                    double balance = 0.0;
                    _repository.CheckBalance(balance);
                    return true;
                }
            }
            return false;
        }



        public bool TopUpBalance(string password, double newBal)
        {
            foreach (User item in bank.users)
            {
                if (item.Password == password)
                {

                    _repository.ToUpBalance(item, newBal);
                    return true;
                }
            }
            return false;
        }



        public bool ChangePassword(string currentpas, string newPass)
        {
            User exicted = default;
            foreach (User item in bank.users)
            {
                if (item.Password == currentpas)
                {
                    exicted = item;
                    _repository.ChangePassword(exicted, newPass);
                    return true;
                }
            }
            return false;
        }


        public bool BankUserList(string email)
        {
            User exicted;
            foreach (User item in bank.users)
            {
                if (item.Email == email)
                {
                    if (item.IsAdmin == true)
                    {
                        exicted = item;
                        _repository.BankUserList();
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }


        public bool BlockUser(string email)
        {
            User exicted;
            foreach (User item in bank.users)
            {
                if (item.Email == email)
                {
                    exicted = item;
                    _repository.BlockUser(exicted);
                    return true;
                }
            }
            return false;
        }

        public void LogOut(User user)
        {
            _repository.LogOut(user);
        }

    }
}