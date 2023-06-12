using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace School_management.Models
{
    public class LoginUser
    {
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        public string Mail { get; set; }
      
        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; set; }

        [Microsoft.Build.Framework.Required]
        public UserType? User_type { get; set; }


    }


}
