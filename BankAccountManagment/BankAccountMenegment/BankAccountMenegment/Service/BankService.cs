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

        public bool CheckBalance(int id)
        {
            foreach (User userList  in _bankRepository.Bank.Users)
            {
                if ( userList.Id == id)
                {
                    _bankRepository.CheckBalance(userList);
                    return true;
                }
            }
            return false;
        }
        public void TopUpBalance(User user, double newBalance)
        {
            if (user.IsLogged ==true)
            {
                user.Balance = newBalance;
            }
        }

    }
}
