using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectWeb.Data;
using ProjectWeb.Models;
namespace ProjectWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db; 

        public BookController(ApplicationDbContext db) 

        {
            _db = db;
        }
       
    
        public IActionResult Index()
        {

            //  var booklist=_context.Bookes.Include(x=>x.Category).Where(x => x.IsArchived==false).OrderByDescending(x=>x.Id).ToList();
       
            IEnumerable<Book> booklist = _db.Bookes.Include(x=>x.Category).ToList();
            return View(booklist);
        }


        public IActionResult create()
        {
            ViewData["CategoryId"] = new SelectList(_db.Categories, "Id", "Name"); //SelectList(table, value, text)
          

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(Book ob)
        {
            //   Book newbook=new Book();
            //         newbook.Name= ob.Name;
            //         newbook.author=ob.author;
            //         newbook.IsArchived=false;
            //         _db.Bookes.Add(newbook);
            //         _db.SaveChanges();

            //  ob.IsArchived=false;
            //  _db.Bookes.Add(ob);
            // _db.SaveChanges();

                _db.Bookes.Add(ob);
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
        var BookFromDb = _db.Bookes.Find(id);
       
        if (BookFromDb == null)
        {
            return NotFound();
        }
           ViewData["CategoryId"] = new SelectList(_db.Categories, "Id", "Name", BookFromDb.CategoryId); //SelectList(table, value, text, value to be selected by default)

            return View(BookFromDb);
    }
   
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Book ob)
    {   
        // var targetBook = _context.Bookes.Where(x => x.Id==ob.Id).FirstOrDefault();
        //     targetBook.Name= ob.Name;
        //     targetBook.author=ob.author;
        //     targetBook.IsArchived=false;
        //     _db.Bookes.Update(targetBook);
        //     _db.SaveChanges();
            
        //  ob.IsArchived=false;
        //  _db.Bookes.Update(ob);
        // _db.SaveChanges();
     
            _db.Bookes.Update(ob);
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
            var BookFromDb = _db.Bookes.Find(id);

            if (BookFromDb == null)
            {
                return NotFound();
            }

            return View(BookFromDb);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult deletePOST(int? id)
        {
            var ob = _db.Bookes.Find(id);
            if (ob == null)
            {
                return NotFound();
            }

            // var targetBook = _context.Bookes.Where(x => x.Id==id).FirstOrDefault();
            //     targetBook.IsArchived=true;
            //    _db.Bookes.Update(targetBook);
            //    _db.SaveChanges();

            _db.Bookes.Remove(ob);
            _db.SaveChanges();
            TempData["success"] = "Deleted successfully";

            return RedirectToAction("Index");
        }

    }
}
