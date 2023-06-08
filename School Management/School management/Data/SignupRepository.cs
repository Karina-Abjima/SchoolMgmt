using Microsoft.AspNetCore.Mvc;
using School_management.Models;
using School_management;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace School_management.Data
{
    public class SignupRepository : ISignupRepository
    {
        private readonly DapperContext _context;

        public SignupRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> PostUserData(User user)
        {
            try { 
            using (var connection = _context.CreateConnection())
            {
                //connection.Open();
                var param = new DynamicParameters();
                param.Add("@Username", user.Username);
                param.Add("@Mail", user.Mail);
                param.Add("@Password", user.Password);
                param.Add("@User_type", user.User_type);
                 
                int IfSignedUp = await connection.ExecuteAsync("signup", param, null, 1000, CommandType.StoredProcedure);
                if (IfSignedUp == 0)
                    return true;
                else return false;
            }
            }
            catch(Exception ex) {
                throw ex;
            }
        }
    }
}
