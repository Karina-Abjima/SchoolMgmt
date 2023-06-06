using Microsoft.AspNetCore.Mvc;
using School_management.Models;

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
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Instantiate the User object and set its properties
                    User newUser = new User(_connectionString)
                    {
                        Username = user.Username,
                        Mail = user.Mail,
                        Password = user.Password,
                        User_type = user.User_type
                    };

                    // Call the Signup method to store user data in the database
                    newUser.Signup();

                    // Redirect to the same page (refresh)
                    return RedirectToAction(nameof(Index));
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
