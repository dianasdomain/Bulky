using BulkyWeb_RazorTemp.Data;
using BulkyWeb_RazorTemp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_RazorTemp.Pages.Categories
{
    //[BindProperties] //binds all the properties you define in this page model
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [BindProperty] //binds this property so it will be available in post handler
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _dbContext.Categories.Add(Category);
            _dbContext.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
