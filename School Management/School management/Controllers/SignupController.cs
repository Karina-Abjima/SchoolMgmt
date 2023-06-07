using Microsoft.AspNetCore.Mvc;
using School_management.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace YourProject.Controllers
{

    public class SignupController : Controller
    {

        private readonly string _connectionString;

       public SignupController(IConfiguration configuration)
{
     _connectionString = configuration.GetConnectionString("Db");
}
        // GET: /Signup
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Signup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var connection = new SqlConnection(_connectionString))
                    {
                        // Open the database connection
                        connection.Open();
                        var updatedrecord = connection.ExecuteAsync("signup", new
                        {
                            user.Username,
                            user.Mail,
                            user.Password,
                            user.User_type
                        }, commandType: CommandType.StoredProcedure);
                        /* Instantiate the User object and set its properties
                        User newUser = new User(_connectionString)
                        {
                            Username = user.Username,
                            Mail = user.Mail,
                            Password = user.Password,
                            User_type = user.User_type
                        };

                         Call the Signup method to store user data in the database*/

                       // connection.Execute("signup", newUser, commandType: CommandType.StoredProcedure);

                        // Redirect to the same page (refresh)
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while creating the user: " + ex.Message);
                }
            }
            

            // If the model state is invalid, return to the signup page with validation errors
            return View(user);
        }
    }
}
