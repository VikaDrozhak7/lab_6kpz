using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBank
{
    public class WithdrawCashStrategy : ITransactionStrategy
    {
        public void Execute(Account account, decimal amount)
        {
            if (account != null)
            {
                account.WithdrawCash(amount);
            }
        }
    }
}
