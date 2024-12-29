using bookStoreWebRezor_Temp.Data;
using bookStoreWebRezor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bookStoreWebRezor_Temp.Pages.Categories
{
    public class editModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public editModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int id)
        {
            Category = _db.Categories.Find(id); // Retrieve the category by ID
            if (Category == null)
            {
                return NotFound(); // Return NotFound if the category doesn't exist
            }
            return Page(); // Display the page with the existing category data
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // If the model state is invalid, return to the page
            }

            var categoryFromDb = _db.Categories.Find(Category.Id); // Find the category in the database
            if (categoryFromDb == null)
            {
                return NotFound(); // Return NotFound if the category doesn't exist
            }

            // Update the properties of the category
            categoryFromDb.Name = Category.Name; // Update the name
            categoryFromDb.DisplayOrder = Category.DisplayOrder; // Update the display order

            _db.Categories.Update(categoryFromDb); // Update the category in the database
            _db.SaveChanges(); // Save changes to the database

            return RedirectToPage("Index"); // Redirect to the index page after the update
        }
    }
}