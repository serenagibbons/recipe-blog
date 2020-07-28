using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipesBlog.Models
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage = "Usernames must be valid email addresses")]
        public string Username { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Passwords must be at least 8 characters long")]
        public string Password { get; set; }
    }
}