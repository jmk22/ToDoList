using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ToDoList.Models;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;

namespace ToDoList.Controllers
{
    public class CategoriesController : Controller
    {
        private ToDoListContext _db = new ToDoListContext();
        public IActionResult Index()
        {
            return View(_db.Categories.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisCategory = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            return View(thisCategory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var thisCategory = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
            return View(thisCategory);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisCategory = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            return View(thisCategory);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisCategory = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            _db.Categories.Remove(thisCategory);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
