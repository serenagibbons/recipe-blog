using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipesBlog.Controllers
{
    public class Recipes1Controller : Controller
    {
        // GET: Recipes
        public ActionResult Index()
        {
            return View("AllRecipes");
        }

    }
}