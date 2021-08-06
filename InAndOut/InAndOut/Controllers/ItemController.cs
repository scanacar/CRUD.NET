using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {

        private readonly ApplicationDbContext _db;  // Sadece databaseden veri çekmek için

        public ItemController(ApplicationDbContext db) // Constructor
        {
            _db = db;
        }
        public IActionResult Index() // Asp-Action Index
        {
            IEnumerable<Item> objList = _db.Items;  // Items Table'ından objList oluşturma
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
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj); // Database'e veri ekleme
            _db.SaveChanges(); // Database'i kaydetme
            return RedirectToAction("Index");  // Index sayfasına otomatik yönlendirme
        }
    }
}
