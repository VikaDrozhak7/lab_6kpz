using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBank.Models
{
    public partial class Account
    {
        public void OnCashWithdrawn()
        {
            CashWithdrawn?.Invoke(this, EventArgs.Empty);
        }

        public void OnCashDeposited()
        {
            CashDeposited?.Invoke(this, EventArgs.Empty);
        }

        public void OnFundsTransferred()
        {
            FundsTransferred?.Invoke(this, EventArgs.Empty);
        }

        public void OnBalanceChecked()
        {
            BalanceChecked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CashWithdrawn;
        public event EventHandler CashDeposited;
        public event EventHandler FundsTransferred;
        public event EventHandler BalanceChecked;
    }
}


