using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryBank;
using LibraryBank.Managers;
using LibraryBank.Models;
using LibraryBank.Repositories;
using LibraryBank.Repositories.Implementations;
using LibraryBank.Repositories.Interfaces;

namespace AppBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAccountRepository accountRepository;
        private Bank bank;
        private AutomatedTellerMachine atm;

        public MainWindow()
        {
            InitializeComponent();

            DatabaseHelper.SetConnectionString(@"Data Source=DESKTOP-GGP8G0N\SQLEXPRESS;Initial Catalog=bank;Integrated Security=True;Encrypt=false;");
            DatabaseHelper databaseHelper = DatabaseHelper.GetInstance();
            accountRepository = new SqlAccountRepository(databaseHelper);

            bank = new Bank("MyBank");
            atm = bank.CreateATM();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cardNumber = CardNumber.Text;
            string pin = Password.Password;
            var accountManager = AccountManager.GetInstance(accountRepository);
            Account clientAccount = accountManager.GetAccount(cardNumber, pin);

            if (clientAccount == null)
            {
                MessageBox.Show("Authentication failed.");
                return;
            }

            MessageBox.Show("Authentication successful!");
            Menu mainForm = new Menu(cardNumber, atm, accountRepository);
            mainForm.Show();
            Hide();
        }
    }
}