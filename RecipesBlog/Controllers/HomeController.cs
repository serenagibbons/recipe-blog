using RecipesBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipesBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Recipes()
        {
            return RedirectToAction("Index", "Recipes");
        }

        public ActionResult Category(string strFilter)
        {
            return RedirectToAction("Category", "Recipes", new { category = strFilter} );
        }

    }
}