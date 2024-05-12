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

namespace AppBank
{
    /// <summary>
    /// Логика взаимодействия для withdraw.xaml
    /// </summary>
    public partial class withdraw : Window
    {
        private DatabaseHelper databaseHelper;
        private string currentCardNumber;
        private AutomatedTellerMachine atm;
        private List<Account> accounts;
        public withdraw(DatabaseHelper dbHelper, string cardNumber)
        {
            InitializeComponent();

            databaseHelper = dbHelper;
            currentCardNumber = cardNumber;
        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            if (databaseHelper == null)
            {
                MessageBox.Show("DatabaseHelper is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (decimal.TryParse(WithdrawAmount.Text, out decimal withdrawAmount) && withdrawAmount > 0)
            {
                try
                {
                    databaseHelper.Withdraw(currentCardNumber, withdrawAmount);
                    MessageBox.Show($"Withdrawal successful! ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    WithdrawAmount.Clear();
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
            Menu mainForm = new Menu(currentCardNumber, accounts, atm, databaseHelper);
            mainForm.Show();
            this.Close();
        }
    }
    }

