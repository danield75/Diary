using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DiaryEntriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<DiaryEntry> diaryEntries = _db.DiaryEntries.ToList();

            return View(diaryEntries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DiaryEntry de)
        {
            if (de != null && de.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title to short");
            }

            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Add(de); // Adds the new diary entry to the database
                _db.SaveChanges(); // Saves the changes to the database

                return RedirectToAction("Index");
            }

            return View(de);
        }
    }
}
