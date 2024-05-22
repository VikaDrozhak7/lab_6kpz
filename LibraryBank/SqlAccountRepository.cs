using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBank
{
    public class SqlAccountRepository : IAccountRepository
    {
        private readonly DatabaseHelper _databaseHelper;

        public SqlAccountRepository(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public Account GetAccount(string cardNumber, string pin)
        {
            return _databaseHelper.GetAccount(cardNumber, pin);
        }

        public decimal GetAccountBalance(string cardNumber)
        {
            return _databaseHelper.GetAccountBalance(cardNumber);
        }

        public void Withdraw(string cardNumber, decimal amount)
        {
            _databaseHelper.Withdraw(cardNumber, amount);
        }

        public void Deposit(string cardNumber, decimal amount)
        {
            _databaseHelper.Deposit(cardNumber, amount);
        }

        public void Transfer(string fromCardNumber, string toCardNumber, decimal amount)
        {
            _databaseHelper.Transfer(fromCardNumber, toCardNumber, amount);
        }
    }

}
