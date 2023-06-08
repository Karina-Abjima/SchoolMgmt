using Microsoft.AspNetCore.Mvc;
using School_management.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using School_management.Data;

namespace YourProject.Controllers
{

    public class SignupController : Controller
    {

        private readonly string _connectionString;
        private readonly ISignupRepository _signupRepository;

        public SignupController(IConfiguration configuration, ISignupRepository signupRepository)
        {
            _connectionString = configuration.GetConnectionString("Db");
            _signupRepository = signupRepository;

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexAsync(User user)
        {
            if (ModelState.IsValid)
            {
                //Task<bool>result =_signupRepository. PostUserData( user);
                //if (result == false)
                //    {
                //    ViewBag.Message = "User Registered!";
                //     }

                //else
                //     {
                //    ViewBag.Message = "User Already Exist!";
                //        }

                //return View();

                bool result = await _signupRepository.PostUserData(user);

                if (result == false)
                {
                    ViewBag.Message = "User Already Exist!";
                }
                else
                {
                    ViewBag.Message = "User Registered!";
                }

                return View();
            }
        
            throw new Exception();
        }
    }
}
//                try
//                {
//                    using (var connection = new SqlConnection(_connectionString))
//                    {
//                        // Open the database connection
//                        connection.Open();
//                        var updatedrecord = connection.ExecuteAsync("signup", new
//                        {
//                            user.Username,
//                            user.Mail,
//                            user.Password,
//                            user.User_type
//                        }, commandType: CommandType.StoredProcedure);
//                        /* Instantiate the User object and set its properties
//                        User newUser = new User(_connectionString)
//                        {
//                            Username = user.Username,
//                            Mail = user.Mail,
//                            Password = user.Password,
//                            User_type = user.User_type
//                        };

//                         Call the Signup method to store user data in the database*/

//                       // connection.Execute("signup", newUser, commandType: CommandType.StoredProcedure);

//                        // Redirect to the same page (refresh)
//                        return RedirectToAction(nameof(Index));
//                    }
//                }
//                catch (Exception ex)
//                {
//                    ModelState.AddModelError("", "An error occurred while creating the user: " + ex.Message);
//                }
//            }
            

//            // If the model state is invalid, return to the signup page with validation errors
//            return View(user);
//        }
//    }
//}
