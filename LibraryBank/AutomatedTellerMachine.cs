using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBank
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

        public void PerformTransaction(Account account, decimal amount)
        {
            _transactionStrategy?.Execute(account, amount);
        }
    }
}