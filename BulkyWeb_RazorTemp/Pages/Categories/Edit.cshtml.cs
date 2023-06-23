using BulkyWeb_RazorTemp.Data;
using BulkyWeb_RazorTemp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_RazorTemp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public Category? Category { get; set; }

        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(int? categoryId)
        {
            if(categoryId != null && categoryId != 0) 
            {
                Category = _dbContext.Categories.Find(categoryId);
            }
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _dbContext.Categories.Update(Category);
                _dbContext.SaveChanges();

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
