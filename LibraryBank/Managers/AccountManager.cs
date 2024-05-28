using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBank.Models;

namespace LibraryBank.Managers
{
    public class AccountManager
    {
        public void WithdrawCash(Account account, decimal amount)
        {
            if (account.Balance >= amount)
            {
                account.Balance -= amount;
                account.OnCashWithdrawn();
            }
            else
            {
                Console.WriteLine("Insufficient funds in the account.");
            }
        }

        public void DepositCash(Account account,decimal amount)
        {
            account.Balance += amount;
            account.OnCashDeposited();
        }

        public void TransferFunds(Account fromAccount, Account toAccount, decimal amount)
        {
            if (toAccount == null)
                throw new ArgumentNullException(nameof(toAccount));
            if (fromAccount == null)
                throw new ArgumentNullException(nameof(fromAccount));

            if (fromAccount.Balance >= amount)
            {
                fromAccount.Balance -= amount;
                toAccount.Balance += amount;
                DepositCash(toAccount, amount);
                toAccount.OnFundsTransferred();
            }
            else
            {
                Console.WriteLine("Insufficient funds in the account.");
            }
        }

        public void CheckBalance(Account account)
        {
            Console.WriteLine($"Account balance: {account.Balance}");
            account.OnBalanceChecked();
        }
    }
}