using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.CategoryPages
{
    public class UpdateModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [BindProperty]
        public Category Category { get; set; }
        public async Task OnGet(int id)
        {
            await LoadData(id);
        }

        private async Task<IActionResult> LoadData(int id)
        {
            Category = await _categoryRepository.GetCategoryById(id);
            if (Category == null)
            {
                TempData["Message"] = "Category not found.";
                return Page();
            }

            return Page();
        }

        public async Task OnPost()
        {
            await _categoryRepository.UpdateCategory(Category);
            TempData["Message"] = "Update category successful";
            await LoadData(Category.CategoryId);
        }
    }
}
