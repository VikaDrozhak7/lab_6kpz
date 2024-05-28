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
using LibraryBank.Repositories.Interfaces;

namespace AppBank
{
    /// <summary>
    /// Логика взаимодействия для tocount.xaml
    /// </summary>
    public partial class tocount : Window
    {
        private IAccountRepository accountRepository;
        private string currentCardNumber;

        public tocount(IAccountRepository accountRepository, string cardNumber)
        {
            InitializeComponent();
            this.accountRepository = accountRepository;
            currentCardNumber = cardNumber;
        }

        private void Deposit_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(DepositAmount.Text, out decimal depositAmount) && depositAmount > 0)
            {
                try
                {
                    accountRepository.Deposit(currentCardNumber, depositAmount);
                    MessageBox.Show($"Deposit successful! Current balance: {accountRepository.GetAccountBalance(currentCardNumber):C}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    DepositAmount.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid amount entered. Please enter a valid numeric value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu mainForm = new Menu(currentCardNumber, null, null, accountRepository);
            mainForm.Show();
            this.Hide();
        }
    }
}

