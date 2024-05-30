using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBank.Managers;
using LibraryBank.Models;

namespace LibraryBank.Stategy.Interfaces
{
    public interface ITransactionStrategy
    {
        void Execute(AccountManager accountManager, Account account, decimal amount);
    }
}
