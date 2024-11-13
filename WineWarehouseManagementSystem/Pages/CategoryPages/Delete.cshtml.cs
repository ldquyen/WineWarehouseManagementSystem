using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.CategoryPages
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public DeleteModel(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        [BindProperty]
        public Category category { get; set; }
        public async Task OnGet(int id)
        {
            category = await _categoryRepository.GetCategoryById(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if(await _productRepository.CheckCategoryInProduct(id))
            {
                TempData["Message"] = "Can not delete this category because it is in product";
                category = await _categoryRepository.GetCategoryById(id);
                return Page();
            }
            else
            {
                var delete = await _categoryRepository.DeleteCategory(id);
                if (delete)
                {
                    TempData["Message"] = "Delete category sucessful";
                    return Page();
                }
                else
                {
                    TempData["Message"] = "Can not delete this category because there is some errors";
                    category = await _categoryRepository.GetCategoryById(id);
                    return Page();
                }
            }
           
        }
    }
}