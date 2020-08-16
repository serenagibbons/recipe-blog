using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RecipesBlog.Models;

namespace RecipesBlog.Controllers
{
    public class RecipesController : Controller
    {
        private RecipesDBEntities db = new RecipesDBEntities();

        // GET: Recipes
        public ActionResult Index(string search)
        {
            var recipes = from item in db.Recipes
                          select item;
            // add search bar functionality
            if (!string.IsNullOrEmpty(search))
            {
                recipes = recipes.Where(item => item.Name.Contains(search) || item.Description.Contains(search));
            }
            return View(recipes.ToList());
        }

        // GET: Recipes/Recipe
        [Route("Recipes/Recipe/{name?}")]
        public ActionResult Recipe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Recipe
        [Route("Recipes/Category/{category?}")]
        public ActionResult Category(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return RedirectToAction("Index");
            }
            var recipes = from item in db.Recipes
                           select item;  
            recipes = recipes.Where(item => item.Category.Contains(category));

            // set ViewBag.Name
            switch(category)
            {
                case "Dessert":
                    ViewBag.Name = "Dessert Recipes";
                    break;
                case "Dinner":
                    ViewBag.Name = "Lunch and Dinner Recipes";
                    break;
                case "Breakfast":
                    ViewBag.Name = "Breakfast Recipes";
                    break;
            }
            return View(recipes.ToList());
        }
    }
}
