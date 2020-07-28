using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipesBlog.Models
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}