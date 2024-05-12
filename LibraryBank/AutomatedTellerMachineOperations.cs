using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBank
{
    public partial class AutomatedTellerMachine
    {
        public void Authenticate(Account account, string enteredCardNumber, string enteredPin)
        {
            if (account != null && account.Authenticate(enteredCardNumber, enteredPin))
            {
                OnAuthenticated();
            }
            else
            {
                Console.WriteLine("Authentication failed. Please check your card number and PIN.");
                OnAuthenticationFailed();
            }
        }

        public void CheckBalance(Account account, DatabaseHelper databaseHelper)
        {
            decimal balance = databaseHelper.GetAccountBalance(account.CardNumber);
            account.Balance = balance;
            OnBalanceChecked();
        }
    }
}
