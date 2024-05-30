using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBank.Models
{
    public partial class Bank
    {
        public string Name { get; set; }
        public List<AutomatedTellerMachine> ATMs { get; set; }

        public Bank(string name)
        {
            Name = name;
            ATMs = new List<AutomatedTellerMachine>();
        }

        public void AddATM(AutomatedTellerMachine atm)
        {
            ATMs.Add(atm);
        }

        public AutomatedTellerMachine CreateATM()
        {

            AutomatedTellerMachine atm = new AutomatedTellerMachine();
            AddATM(atm);
            return atm;
        }
    }
}
