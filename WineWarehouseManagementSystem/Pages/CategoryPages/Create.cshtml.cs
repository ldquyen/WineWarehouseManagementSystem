using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.CategoryPages
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateModel()
        {
            _categoryRepository = new CategoryRepository();
        }

        [BindProperty]
        public Category category { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (await _categoryRepository.CheckCategoryName(category.CategoryName))
            {
                TempData["Message"] = "Duplicate category name";
                return Page();
            }
            else
            {
                await _categoryRepository.CreateCategory(category);
                TempData["Message"] = "Create category successful";
                return Page();
            }
            
        }
    }
}
