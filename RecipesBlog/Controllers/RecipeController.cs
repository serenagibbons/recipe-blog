using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipesBlog.Models;

namespace RecipesBlog.Controllers
{
    public class RecipeController : Controller
    {
        private RecipesDBEntities _db = new RecipesDBEntities();

        // GET: Recipe
        public ActionResult Index()
        {
            return View(_db.RecipesSet.ToList());
        }

        //

        // GET: /Recipe/Details/5 

        public ActionResult Details(int id)

        {
            return View();
        }

        //

        // GET: /Recipe/Create 

        public ActionResult Create()

        {
            return View();
        }

        //

        // POST: /Recipe/Create 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Create(FormCollection collection)

        {

            try

            {
                // TODO: Add insert logic here 

                return RedirectToAction("Index");
            }

            catch

            {
                return View();
            }

        }

        //

        // GET: /Recipe/Edit/5

        public ActionResult Edit(int id)

        {
            return View();
        }

        //

        // POST: /Recipe/Edit/5 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Edit(int id, FormCollection collection)

        {

            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }

            catch
            {
                return View();

            }

        }

    }
}