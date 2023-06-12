using Microsoft.AspNetCore.Mvc;
using School_management.Data;
using School_management.Models;

using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using School_management.Data;


namespace School_management.Controllers
{
    public class LoginController:Controller
    {
        private readonly string _connectionString;
        private readonly IUserRepository _userRepository;

        public LoginController(IConfiguration configuration, IUserRepository userRepository)
        {
            _connectionString = configuration.GetConnectionString("Db");
            _userRepository = userRepository;

        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Output(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                // Validate the user credentials
                bool isValid = await _userRepository.ValidateCredentials(loginUser);

                if (isValid)
                {
                    
                   return RedirectToAction("AfterLogin", "Signup");
                }
                else
                {
                    // Display an error message for invalid credentials
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }

            // If the model state is invalid, return the login view with validation errors
            return View();
        }


        //public IActionResult Login(User user)
        //{
        //    bool isValid = _userRepository.ValidateCredentials(user.Mail, user.Password);

        //    if (isValid)
        //    {
        //        HttpContext.Session.SetString("Email", user.Mail);
        //        return RedirectToAction("NewPage"); // Redirect to a new page
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Invalid email or password.");
        //        return View(user);
        //    }
        //}

    }
}
