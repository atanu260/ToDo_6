using Microsoft.AspNetCore.Mvc;
using WebApp1_6.Data;
using WebApp1_6.Models;

namespace WebApp1_6.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<CategoryModel> categories = _context.Category;
            return View(categories);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The name and Displayorder should not be same");
            }

            if (ModelState.IsValid)
            {
                _context.Category.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryDb = _context.Category.Find(id);
            if (categoryDb == null)
            {
                return NotFound();
            }
            return View(categoryDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryModel obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The name and Displayorder should not be same");
            }

            if (ModelState.IsValid)
            {
                _context.Category.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryDb = _context.Category.Find(id);
            if (categoryDb == null)
            {
                return NotFound();
            }
            return View(categoryDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CategoryModel obj)
        {

            _context.Category.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
            
            //return View(obj);
        }
    }
}
