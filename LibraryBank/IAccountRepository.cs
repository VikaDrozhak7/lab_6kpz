using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBank
{
    public interface IAccountRepository
    {
        Account GetAccount(string cardNumber, string pin);
        decimal GetAccountBalance(string cardNumber);
        void Withdraw(string cardNumber, decimal amount);
        void Deposit(string cardNumber, decimal amount);
        void Transfer(string fromCardNumber, string toCardNumber, decimal amount);
    }

}
