using Dapper;
using School_management.Models;
using System.Data;
using System.Data.SqlClient;

namespace School_management.Data
{
    public class UserRepository:IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateCredentials(LoginUser loginuser)
        {
            using (var connection =_context.CreateConnection()) //using (var connection = _context.CreateConnection())
            {
               
                    var param = new DynamicParameters();
                    param.Add("@Mail", loginuser.Mail);
                    param.Add("@Password", loginuser.Password); 
                    param.Add("@User_type", loginuser.User_type.Value);

                    bool result = await connection.ExecuteScalarAsync<bool>("ValidateCredentials", param, commandType: CommandType.StoredProcedure);
                // return result;

                // Return true if the result is 1 (valid credentials), otherwise false
                return result;
            }
        }

    }
}
