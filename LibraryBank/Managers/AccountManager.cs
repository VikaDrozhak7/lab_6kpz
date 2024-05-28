using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBank.Models;
using LibraryBank.Repositories.Interfaces;

namespace LibraryBank.Managers
{
    public class AccountManager
    {
        private readonly IAccountRepository _accountRepository;
        private static AccountManager _instance;
        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public static AccountManager GetInstance(IAccountRepository accountRepository)
        {
            if (_instance == null)
            {
                _instance = new AccountManager(accountRepository);
            }
            return _instance;
        }
        
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

        public decimal CheckBalance(Account account)
        {
            var loadedBalance = _accountRepository.GetAccountBalance(account.CardNumber);
            account.Balance = loadedBalance;
            Console.WriteLine($"Account balance: {loadedBalance}");
            account.OnBalanceChecked();
            return loadedBalance;
        }

        public Account GetAccount(string cardNumber, string pin)
            => _accountRepository.GetAccount(cardNumber, pin);
        
        public bool IsAuthenticated(string enteredCardNumber, string enteredPin)
        {
            return _accountRepository.GetAccount(enteredCardNumber, enteredPin) != null;
        }
    }
}