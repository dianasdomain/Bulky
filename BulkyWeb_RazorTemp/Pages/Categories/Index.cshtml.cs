using BulkyWeb_RazorTemp.Data;
using BulkyWeb_RazorTemp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_RazorTemp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public List<Category> Categories { get; set; }

        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Categories = _dbContext.Categories.ToList();
        }
    }
}
