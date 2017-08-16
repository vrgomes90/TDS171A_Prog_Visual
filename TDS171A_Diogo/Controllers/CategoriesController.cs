using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDS171A_Diogo.Models;

namespace TDS171A_Diogo.Controllers
{
    public class CategoriesController : Controller
    {
        private static IList<Category> categoryList = new List<Category>() {
            new Category() { CategoryId = 1, Name = "Joao" },
            new Category() { CategoryId = 2, Name = "Maria" },
            new Category() { CategoryId = 3, Name = "José" },
            new Category() { CategoryId = 4, Name = "Josefa" },
            new Category() { CategoryId = 5, Name = "Pedro" }
        };

        // GET: Categories
        public ActionResult Index()
        {
            return View(categoryList.OrderBy(c => c.Name));
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(long id)
        {
            var category = categoryList
                .Where(c => c.CategoryId == id)
                .First();
            return View(category);
        }

        public ActionResult Edit(long id)
        {
            var category = categoryList
                .Where(c => c.CategoryId == id)
                .First();
            return View(category);
        }

        public ActionResult Delete(long id)
        {
            var category = categoryList
                .Where(c => c.CategoryId == id)
                .First();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Category category)
        {
            categoryList.Add(category);

            category.CategoryId =
                categoryList.Max(c => c.CategoryId) + 1;
            return RedirectToAction("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Category modifield)
        {
            var category = categoryList
                .Where(c => c.CategoryId == modifield.CategoryId)
                .First();

            category.Name = modifield.Name;

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Details(Category modifield)
        {
            var category = categoryList
                .Where(c => c.CategoryId == modifield.CategoryId)
                .First();

            category.Name = modifield.Name;

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(Category toDelete)
        {
            var category = categoryList
                .Where(c => c.CategoryId == toDelete.CategoryId)
                .First();

            category.Name = toDelete.Name;

            return RedirectToAction("Index");
        }

    }
}