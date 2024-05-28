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
    /// Логика взаимодействия для Transfer.xaml
    /// </summary>
    public partial class Transfer : Window
    {
        private IAccountRepository accountRepository;
        private string currentCardNumber;

        public Transfer(IAccountRepository accountRepository, string cardNumber)
        {
            InitializeComponent();
            this.accountRepository = accountRepository;
            currentCardNumber = cardNumber;
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            string recipientCardNumber = CardNumber.Text;
            if (decimal.TryParse(TransferAmount.Text, out decimal transferAmount) && transferAmount > 0)
            {
                try
                {
                    accountRepository.Transfer(currentCardNumber, recipientCardNumber, transferAmount);
                    MessageBox.Show($"Transfer successful! Sender balance: {accountRepository.GetAccountBalance(currentCardNumber):C}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    CardNumber.Clear();
                    TransferAmount.Clear();
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

