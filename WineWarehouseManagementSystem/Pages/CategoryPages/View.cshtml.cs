using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject.Models;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.CategoryPages
{
    public class ViewCategoryModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;
        public List<Category> CategoriesList { get; set; }
        public ViewCategoryModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task OnGet(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                CategoriesList = await _categoryRepository.GetAlls();
            }
            else
            {
                await OnGetSearchByName(name);
            }
        }

        public async Task<IActionResult> OnGetSearchByName(string name)
        {
            CategoriesList = await _categoryRepository.GetCategoryByName(name);
            return Page();
        }
    }
}
