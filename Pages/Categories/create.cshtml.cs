using bookStoreWebRezor_Temp.Data;
using bookStoreWebRezor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bookStoreWebRezor_Temp.Pages.Categories
{
    public class createModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public createModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");

        }
    }
}
