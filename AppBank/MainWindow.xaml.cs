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
        private List<Account> accounts;

        public MainWindow()
        {
            InitializeComponent();

            DatabaseHelper databaseHelper = DatabaseHelper.GetInstance(@"Data Source=DESKTOP-GGP8G0N\SQLEXPRESS;Initial Catalog=bank;Integrated Security=True;Encrypt=false;");
            accountRepository = new SqlAccountRepository(databaseHelper);

            bank = new Bank("MyBank");
            atm = bank.CreateATM();
            accounts = new List<Account>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cardNumber = CardNumber.Text;
            string pin = Password.Password;

            Account clientAccount = accountRepository.GetAccount(cardNumber, pin);

            if (clientAccount != null)
            {
                MessageBox.Show("Authentication successful!");
                Menu mainForm = new Menu(cardNumber, accounts, atm, accountRepository);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Authentication failed.");
            }
        }
    }
}