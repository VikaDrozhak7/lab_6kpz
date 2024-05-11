using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBank
{
    public partial class Account
    {
        public void WithdrawCash(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                OnCashWithdrawn();
            }
            else
            {
                Console.WriteLine("Insufficient funds in the account.");
            }
        }

        public void DepositCash(decimal amount)
        {
            Balance += amount;
            OnCashDeposited();
        }

        public void TransferFunds(Account toAccount, decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                toAccount.DepositCash(amount);
                OnFundsTransferred();
            }
            else
            {
                Console.WriteLine("Insufficient funds in the account.");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Account balance: {Balance}");
            OnBalanceChecked();
        }
    }
}
