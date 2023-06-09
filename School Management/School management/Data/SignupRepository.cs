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

        public async Task<string> PostUserData(User user)
        {
            try { 
            using (var connection = _context.CreateConnection())
            {
                //connection.Open();
                var param = new DynamicParameters();
                param.Add("@Username", user.Username);
                param.Add("@Mail", user.Mail);
                param.Add("@Password", user.Password);
                param.Add("@User_type",user.User_type.Value);

                    int IfSignedUp= connection.ExecuteScalar<int>("signup", param, commandType: CommandType.StoredProcedure);

                    //int IfSignedUp = param.Get<int>("@resultVal");
                    if (IfSignedUp == 0)
                    {
                        return "User Registered!";
                    }
                    else
                    { 
                        return "Already Exist";
                        }
            }
            }
            catch(Exception ex) {
                throw ex;
            }
        }
    }
}
