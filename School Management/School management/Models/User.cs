using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Build.Framework;

namespace School_management.Models
{
   
    public class User
    {
        [Microsoft.Build.Framework.Required] [MinLength(4)] public string ?Username { get; set; }


        [Microsoft.Build.Framework.Required] [EmailAddress] public string ?Mail { get; set; }
        [Microsoft.Build.Framework.Required][PasswordPropertyText]  public string ?Password { get; set; }
        //public enum userType {Student,Teacher,Principal };
        //[Display(Name = "Select type")]
        //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please select your major.")]
        //[EnumDataType(typeof(userType))]
        public UserType ?User_type { get; set; }


        //private readonly string _connectionString;

        //public User(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        //public void Signup()
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        connection.Execute("signup", this, commandType: CommandType.StoredProcedure);
        //    }
        //}
        public User()
        {
            
        }
    }
}
