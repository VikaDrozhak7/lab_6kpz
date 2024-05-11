using System;
using System.Data.SqlClient;

namespace LibraryBank
{
    public partial class DatabaseHelper
    {
        private static DatabaseHelper _instance;
        private string _connectionString;

        private DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static DatabaseHelper GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new DatabaseHelper(connectionString);
            }
            return _instance;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
