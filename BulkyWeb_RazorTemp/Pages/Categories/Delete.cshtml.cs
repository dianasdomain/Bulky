using BulkyWeb_RazorTemp.Data;
using BulkyWeb_RazorTemp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_RazorTemp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(int? categoryId)
        {
            if (categoryId != null && categoryId != 0)
            {
                Category = _dbContext.Categories.Find(categoryId);
            }
        }

        public IActionResult OnPost()
        {
            Category? obj = _dbContext.Categories.Find(Category.CategoryId);

            if (obj == null)
            {
                return NotFound();
            }

            _dbContext.Categories.Remove(obj);
            _dbContext.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
