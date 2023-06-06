using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace School_management.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string User_type { get; set; }

        private readonly string _connectionString;

        public User(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Signup()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("signup", this, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
