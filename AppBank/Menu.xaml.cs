using LibraryBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LibraryBank.Models;
using LibraryBank.Repositories.Interfaces;

namespace AppBank
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Bank bank = new Bank("MyBank");
        AutomatedTellerMachine atm;
        List<Account> accounts;
        string cardNumber;
        private IAccountRepository accountRepository;
        private Account clientAccount;

        public Menu(string cardNumber, List<Account> accounts, AutomatedTellerMachine atm, IAccountRepository accountRepository)
        {
            this.cardNumber = cardNumber;
            this.accounts = accounts;
            this.atm = atm;
            this.accountRepository = accountRepository;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal balance = accountRepository.GetAccountBalance(cardNumber);

            if (balance >= 0)
            {
                ShowMessageBox($"Current balance: {balance}");
            }
            else
            {
                ShowMessageBox("Account not found.");
            }
        }

        private void ShowMessageBox(string message)
        {
            MessageBox.Show(message, "Bank App", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tocount depositcash = new tocount(accountRepository, cardNumber);
            depositcash.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Transfer transferCash = new Transfer(accountRepository, cardNumber);
            transferCash.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            withdraw withdrawCash = new withdraw(accountRepository, cardNumber);
            withdrawCash.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
