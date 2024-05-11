using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibraryBank
{
    public partial class DatabaseHelper
    {
        public Account GetAccount(string cardNumber, string pin)
        {
            string query = "SELECT * FROM Accounts WHERE CardNumber = @CardNumber AND PinCode = @PinCode";

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CardNumber", cardNumber);
                    command.Parameters.AddWithValue("@PinCode", pin);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Account account = new Account();

                            account.OwnerName = reader.GetString(reader.GetOrdinal("OwnerName"));
                            account.CardNumber = reader.GetString(reader.GetOrdinal("CardNumber"));

                            return account;
                        }
                    }
                }
            }

            return null;
        }

        public decimal GetAccountBalance(string cardNumber)
        {
            string query = "SELECT Balance FROM Accounts WHERE CardNumber = @CardNumber";

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CardNumber", cardNumber);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                }
            }

            return 0;
        }

        public void Withdraw(string cardNumber, decimal amount)
        {
            string query = "UPDATE Accounts SET Balance = Balance - @Amount WHERE CardNumber = @CardNumber";

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CardNumber", cardNumber);
                    command.Parameters.AddWithValue("@Amount", amount);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Deposit(string cardNumber, decimal amount)
        {
            string query = "UPDATE Accounts SET Balance = Balance + @Amount WHERE CardNumber = @CardNumber";

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CardNumber", cardNumber);
                    command.Parameters.AddWithValue("@Amount", amount);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Transfer(string fromCardNumber, string toCardNumber, decimal amount)
        {
            Withdraw(fromCardNumber, amount);
            Deposit(toCardNumber, amount);
        }
    }
}



