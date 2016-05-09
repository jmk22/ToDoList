using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ToDoList.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private ToDoListContext _db = new ToDoListContext();
        public IActionResult Index()
        {
            return View(_db.Items.Include(i => i.Category).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisItem = _db.Items.FirstOrDefault(i => i.ItemId == id);
            return View(thisItem);
        }
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisItem = _db.Items.FirstOrDefault(i => i.ItemId == id);
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
            return View(thisItem);
        }
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisItem = _db.Items.FirstOrDefault(i => i.ItemId == id);
            return View(thisItem);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisItem = _db.Items.FirstOrDefault(i => i.ItemId == id);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
