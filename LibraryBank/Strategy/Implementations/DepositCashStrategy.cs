using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBank.Managers;
using LibraryBank.Models;
using LibraryBank.Stategy.Interfaces;

namespace LibraryBank.Stategy.Implementations
{
    public class DepositCashStrategy : ITransactionStrategy
    {
        public void Execute(AccountManager accountManager, Account account, decimal amount)
        {
            if (accountManager != null || account != null)
            {
                accountManager.DepositCash(account, amount);
            }
        }
    }
}