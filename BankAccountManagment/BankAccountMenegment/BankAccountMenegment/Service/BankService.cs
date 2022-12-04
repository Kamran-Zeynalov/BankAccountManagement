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
        readonly IBankRepository _bankRepository;

        public BankService()
        {
            _bankRepository = new BankRepository();
        }

        public bool CheckBalance(string password)
        {
            foreach (User userList in _bankRepository.Bank.Users)
            {
                if (userList.Password == password)
                {
                    Console.Write("Balance");
                    _bankRepository.CheckBalance(userList);
                    Thread.Sleep(2000);

                    return true;
                }
            }
            Console.WriteLine("Sehf");
            Thread.Sleep(2000);
            return false;
        }
        public bool TopUpBalance(string password, double newBalance)
        {
            foreach (User user1 in _bankRepository.Bank.Users)
            {
                if (user1.Password == password)
                {
                    user1.Balance = newBalance;
                    _bankRepository.TopUpBalance(user1);
                    return true;
                }
            }
            return false;
        }
        public bool ChangePassword(string pastPw, string newPw)
        {
            User exicted = default;
            foreach (User pw in _bankRepository.Bank.Users)
            {
                if (pw.Password == pastPw)
                {
                    exicted = pw;
                    _bankRepository.ChangePassword(exicted, newPw);
                    return true;
                }
            }
            return false;
        }
        public bool BlockUser(string email)
        {
            User existed;
            foreach (User userr in _bankRepository.Bank.Users)
            {
                if (userr.Email == email)
                {

                        existed = userr;
                        _bankRepository.BlockUser(existed);
                        return true;
                }
            }
            return false;
        }

        public void LogOut(User user)
        {
            _bankRepository.LogOut(user);
        }

        public bool UserList(string email)
        {
            User result;
            foreach (User userr in _bankRepository.Bank.Users)
            {
                if (userr.Email == email)
                {
                    if (userr.IsAdmin == true)
                    {
                        result = userr;
                        _bankRepository.BankUserList();
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
    }
}
