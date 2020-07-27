using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipesBlog.Models;

namespace RecipesBlog.Controllers
{
    public class RecipesController : Controller
    {
        private RecipesDBEntities db = new RecipesDBEntities();

        // GET: Recipes
        public ActionResult Index()
        {
            return View(db.Recipes.ToList());
        }

        // GET: Recipes table view
        public ActionResult List()
        {
            return View(db.Recipes.ToList());
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

        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {                
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Ingredients,Directions,Source,Category,Image_URL")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Recipes/Recipe
        [Route("Recipes/Category/{category?}")]
        public ActionResult Category(string category)
        {
            if (category == null)
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
