using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _dbContext.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())  //custom validation
            //{
            //    ModelState.AddModelError("name", "Display order cannot match the name.");
            //}

            //if (obj.Name != null && obj.Name.ToLower() == "test")  //custom validation
            //{
            //    ModelState.AddModelError("", "Test is an invalid value.");
            //}

            if (ModelState.IsValid) //server side validation
            {
                _dbContext.Categories.Add(obj);
                _dbContext.SaveChanges();

                TempData["success"] = "Category created successfully";

                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        public IActionResult Edit(int? categoryId) //get
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }

            Category? category = _dbContext.Categories.Find(categoryId); //find only works on primary key
            Category? category1 = _dbContext.Categories.FirstOrDefault(u => u.CategoryId == categoryId);
            Category? category2 = _dbContext.Categories.Where(u => u.CategoryId == categoryId).FirstOrDefault();

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid) //server side validation
            {
                _dbContext.Categories.Update(obj);
                _dbContext.SaveChanges();

                TempData["success"] = "Category edited successfully";

                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        public IActionResult Delete(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }

            Category? category = _dbContext.Categories.Find(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? categoryId)
        {
            Category? category = _dbContext.Categories.Find(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            TempData["success"] = "Category deleted successfully";

            return View();
        }
    }
}
