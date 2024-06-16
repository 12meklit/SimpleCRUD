using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectWeb.Data;
using ProjectWeb.Models;
namespace ProjectWeb.Controllers
{
    public class studentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public studentController(ApplicationDbContext db)

        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<student> studentlist = _db.Students.ToList();
            return View(studentlist);
        }

        public IActionResult create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(student ob)
        {

            _db.Students.Add(ob);
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
            var studentFromDb = _db.Students.Find(id);

            if (studentFromDb == null)
            {
                return NotFound();
            }
         
            return View(studentFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(student ob)
        {

            _db.Students.Update(ob);
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
            var studentFromDb = _db.Students.Find(id);

            if (studentFromDb == null)
            {
                return NotFound();
            }

            return View(studentFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult deletePOST(int? id)
        {
            var ob = _db.Students.Find(id);
            if (ob == null)
            {
                return NotFound();
            }
            _db.Students.Remove(ob);
            _db.SaveChanges();
            TempData["success"] = "Deleted successfully";

            return RedirectToAction("Index");
        }

    }
}