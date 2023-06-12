using Microsoft.AspNetCore.Mvc;
using School_management.Models;
using School_management;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Data.Common;

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
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var param = new DynamicParameters();
                    param.Add("@Username", user.Username);
                    param.Add("@Mail", user.Mail);
                    param.Add("@Password", user.Password);
                    param.Add("@User_type", user.User_type.Value);

                    bool result = await connection.ExecuteScalarAsync<bool>("signup", param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
