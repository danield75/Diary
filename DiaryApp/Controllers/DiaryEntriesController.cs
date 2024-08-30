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
        public IActionResult Create(DiaryEntry diaryEntry)
        {
            if (diaryEntry != null && diaryEntry.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title to short");
            }

            if (diaryEntry != null && ModelState.IsValid)
            {
                _db.DiaryEntries.Add(diaryEntry); // Adds the new diary entry to the database
                _db.SaveChanges(); // Saves the changes to the database

                return RedirectToAction("Index");
            }

            return View(diaryEntry);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry diaryEntry)
        {
            if (diaryEntry != null && diaryEntry.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title to short");
            }

            if (diaryEntry != null && ModelState.IsValid)
            {
                _db.DiaryEntries.Update(diaryEntry); // Updates the diary entry
                _db.SaveChanges(); // Saves the changes

                return RedirectToAction("Index");
            }

            return View(diaryEntry);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }
    }
}
