using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Data;
using ProjectWeb.Models;
using System.Linq;

namespace ProjectWeb.Controllers
{
    public class CategoryController1 : Controller
    {
        private readonly ApplicationDbContext _db; //this is dependency injection

        public CategoryController1(ApplicationDbContext db) //this is the constructor of the controller whcih is called by default when the controller is called

        {
            _db = db;
        }

        public IActionResult Index() //action or function the url will be /Co
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        //GET
        public IActionResult create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder canot exacty match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"]="Created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    

    //GET
    public IActionResult Edit(int? id)
    {
        if(id== null || id==0)
        {
            return NotFound();
        }
        var CategoryFromDb= _db.Categories.Find(id);
       // var CategoryFromDbFirst= _db.Categories.FirstOrDefault(u=>u.Id==id);
        //var CategoryFromDbsingle = _db.Categories.SingleOrDefault(u => u.Id == id);
        if (CategoryFromDb==null) 
            {
                return NotFound();
            }

            return View(CategoryFromDb);
    }


    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder canot exacty match the Name.");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
                TempData["success"] = "updated successfully";

                return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var CategoryFromDb = _db.Categories.Find(id);
        // var CategoryFromDbFirst= _db.Categories.FirstOrDefault(u=>u.Id==id);
        //var CategoryFromDbsingle = _db.Categories.SingleOrDefault(u => u.Id == id);
        if (CategoryFromDb == null)
        {
            return NotFound();
        }

        return View(CategoryFromDb);
    }


    //POST
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {

            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                    return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "deleted successfully";

            return RedirectToAction("Index");
        
        
    }
}
    }

