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
        public AutomatedTellerMachine AutomatedTellerMachine { get; set; }
        private readonly IAccountRepository _accountRepository;
        
        public AutomatedTellerMachineManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public void Authenticate(Account account, string enteredCardNumber, string enteredPin)
        {
            if (account != null && account.Authenticate(enteredCardNumber, enteredPin))
            {
                AutomatedTellerMachine.OnAuthenticated();
            }
            else
            {
                Console.WriteLine("Authentication failed. Please check your card number and PIN.");
                AutomatedTellerMachine.OnAuthenticationFailed();
            }
        }

        public void CheckBalance(Account account)
        {
            decimal balance = _accountRepository.GetAccountBalance(account.CardNumber);
            account.Balance = balance;
            AutomatedTellerMachine.OnBalanceChecked();
        }
    }
}
