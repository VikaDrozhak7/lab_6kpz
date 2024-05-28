using System;
using System.Data.SqlClient;

namespace LibraryBank.Repositories
{
    public class DatabaseHelper
    {
        private static DatabaseHelper _instance;
        private string _connectionString;
        
        private DatabaseHelper(string connectionString = null)
        {
            _connectionString = connectionString;
        }

        public static DatabaseHelper GetInstance(string connectionString = null)
        {
            if (_instance == null)
            {
                _instance = new DatabaseHelper(connectionString);
            }

            return _instance;
        }

        public static void SetConnectionString(string connectionString)
        {
            _instance = new DatabaseHelper(connectionString);
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}