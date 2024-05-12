using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBank
{
    public partial class Account
    {
        private void OnCashWithdrawn()
        {
            CashWithdrawn?.Invoke(this, EventArgs.Empty);
        }

        private void OnCashDeposited()
        {
            CashDeposited?.Invoke(this, EventArgs.Empty);
        }

        private void OnFundsTransferred()
        {
            FundsTransferred?.Invoke(this, EventArgs.Empty);
        }

        private void OnBalanceChecked()
        {
            BalanceChecked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CashWithdrawn;
        public event EventHandler CashDeposited;
        public event EventHandler FundsTransferred;
        public event EventHandler BalanceChecked;
    }
}


