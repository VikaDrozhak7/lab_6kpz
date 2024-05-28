using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBank.Models
{
    public partial class Account
    {
        public string CardNumber { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }
        private string PinCode { get; set; }
        
        public bool Authenticate(string enteredCardNumber, string enteredPin)
        {
            return this.CardNumber == enteredCardNumber && this.PinCode == enteredPin;
        }
    }
}
