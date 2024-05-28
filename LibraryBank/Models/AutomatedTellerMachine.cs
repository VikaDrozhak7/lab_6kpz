using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBank.Managers;
using LibraryBank.Stategy.Interfaces;

namespace LibraryBank.Models
{
    public partial class AutomatedTellerMachine
    {
        public decimal Cash { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }

        private ITransactionStrategy _transactionStrategy;

        public void SetTransactionStrategy(ITransactionStrategy strategy)
        {
            _transactionStrategy = strategy;
        }

        public void PerformTransaction(AccountManager accountManager, Account account, decimal amount)
        {
            _transactionStrategy?.Execute(accountManager, account, amount);
        }
    }
}