using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectWeb.Data;
using ProjectWeb.Models;


namespace ProjectWeb.Controllers
{
    public class StudentBorrowController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentBorrowController(ApplicationDbContext db)

        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<StudentBorrow> borrowdlist = _db.StudentBorrowes.Include(x => x.student).Include(x => x.Book).ToList();
            return View(borrowdlist);
        }
        public IActionResult create()
        {
            ViewData["StudentId"] = new SelectList(_db.Students, "Id", "FullName");
            ViewData["BookId"] = new SelectList(_db.Bookes, "Id", "Title"); 

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(StudentBorrow ob)
        {

            _db.StudentBorrowes.Add(ob);
            _db.SaveChanges();
            TempData["success"] = "Created successfully";
            return RedirectToAction("Index");

            return View(ob);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var BorrowFromDb = _db.StudentBorrowes.Find(id);

            if (BorrowFromDb == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_db.Students, "Id", "FullName", BorrowFromDb.StudentId);
            ViewData["BookId"] = new SelectList(_db.Bookes, "Id", "Title", BorrowFromDb.BookID);

            return View(BorrowFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentBorrow ob)
        {

            _db.StudentBorrowes.Update(ob);
            _db.SaveChanges();
            TempData["success"] = "updated successfully";
            return RedirectToAction("Index");

            return View(ob);
        }
        public IActionResult delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var BorrowFromDb = _db.StudentBorrowes.Find(id);

            if (BorrowFromDb == null)
            {
                return NotFound();
            }

            return View(BorrowFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult deletePOST(int? id)
        {
            var ob = _db.StudentBorrowes.Find(id);
            if (ob == null)
            {
                return NotFound();
            }
            _db.StudentBorrowes.Remove(ob);
            _db.SaveChanges();
            TempData["success"] = "Deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
