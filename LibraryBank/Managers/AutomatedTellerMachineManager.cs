using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBank.Models;
using LibraryBank.Repositories.Interfaces;

namespace LibraryBank.Managers
{
    public class AutomatedTellerMachineManager
    {
        private readonly IAccountRepository _accountRepository;
        private static AutomatedTellerMachineManager _instance;
        public AutomatedTellerMachineManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public static AutomatedTellerMachineManager GetInstance(IAccountRepository accountRepository)
        {
            if (_instance == null)
            {
                _instance = new AutomatedTellerMachineManager(accountRepository);
            }
            return _instance;
        }
        public bool Authenticate(AutomatedTellerMachine atm, string enteredCardNumber, string enteredPin)
        {
            if (enteredCardNumber == null || enteredPin == null)
            {
                Console.WriteLine("Authentication failed. Please check your card number or PIN.");
                atm.OnAuthenticationFailed();
                return false;
            }
            var accountManager = AccountManager.GetInstance(_accountRepository);
            if (accountManager.IsAuthenticated(enteredCardNumber, enteredPin))
            {
                atm.OnAuthenticated();
                return true;
            }
            Console.WriteLine("Authentication failed. Please check your card number or PIN.");
            atm.OnAuthenticationFailed();
            return false;
        }

        public void CheckBalance(AutomatedTellerMachine atm, Account account)
        {
            var accountManager = AccountManager.GetInstance(_accountRepository);
            decimal balance = _accountRepository.GetAccountBalance(account.CardNumber);
            account.Balance = balance;
            atm.OnBalanceChecked();
        }
    }
}
