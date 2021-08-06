using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
            return View(objList);
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            if(ModelState.IsValid)  // Model mevcutsa yani database varsa
            {
                _db.Expenses.Add(obj); // Veri ekleme
                _db.SaveChanges();  // Kaydetme
                return RedirectToAction("Index");  // Indexe oto yönlendirme
            }
            return View(obj);
        }
        
        // GET-Delete
        public IActionResult Delete(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);  // Id ile databasede arama
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        // POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expenses.Find(id); // Id ile databasede arama
            if (obj == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(obj);  // Veriyi silme
            _db.SaveChanges();  // Kaydetme
            return RedirectToAction("Index");
        }

        // GET-Update
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)  // Database mevcutsa
            {
                _db.Expenses.Update(obj);  // Veriyi güncelle
                _db.SaveChanges(); // Kaydet
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
