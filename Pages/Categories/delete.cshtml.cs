using bookStoreWebRezor_Temp.Data;
using bookStoreWebRezor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bookStoreWebRezor_Temp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Category Category { get; set; }

        public IActionResult OnGet(int id)
        {
            Category = _db.Categories.Find(id); // Retrieve the category by ID
            if (Category == null)
            {
                return NotFound(); // Return NotFound if the category doesn't exist
            }
            return Page(); // Display the confirmation page with the category details
        }

        public IActionResult OnPost()
        {
            if (Category == null)
            {
                return NotFound(); // Return NotFound if the category is null
            }

            var categoryFromDb = _db.Categories.Find(Category.Id); // Find the category in the database
            if (categoryFromDb == null)
            {
                return NotFound(); // Return NotFound if the category doesn't exist
            }

            _db.Categories.Remove(categoryFromDb); // Remove the category from the database
            _db.SaveChanges(); // Save changes to the database
            TempData["success"] = "category deleted successfully";

            return RedirectToPage("Index"); // Redirect to the index page after deletion
        }
    }
}