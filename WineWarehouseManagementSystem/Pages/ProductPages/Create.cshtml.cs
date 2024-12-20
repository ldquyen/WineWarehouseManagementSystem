using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Interface;
using Repositories.Repository;
namespace WineWarehouseManagementSystem.Pages.ProductPages
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        [BindProperty]
        public Product Product { get; set; }
        public SelectList CategoryList { get; set; }

        public CreateModel(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public async Task<IActionResult> OnGet()
        {
            var categories = await _categoryRepository.GetAlls();
            CategoryList = new SelectList(categories, "CategoryId", "CategoryName");
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var categorie = await _categoryRepository.GetAlls();
                CategoryList = new SelectList(categorie, "CategoryId", "CategoryName");
                TempData["Message"] = "Create product fail";
                return Page();
            }
            if(string.IsNullOrEmpty(Product.ProductName) || string.IsNullOrEmpty(Product.ProductDescription) || string.IsNullOrEmpty(Product.Origin))
            {
                var categorie = await _categoryRepository.GetAlls();
                CategoryList = new SelectList(categorie, "CategoryId", "CategoryName");
                TempData["Message"] = "Create product fail, please input all fields";
                return Page();
            }
            if (await _productRepository.CheckProductName(Product.ProductName))
            {
                var categorie = await _categoryRepository.GetAlls();
                CategoryList = new SelectList(categorie, "CategoryId", "CategoryName");
                TempData["Message"] = "Create product fail, duplicate product name";
                return Page();
            }
            await _productRepository.CreateProduct(Product);
            var categories = await _categoryRepository.GetAlls();
            CategoryList = new SelectList(categories, "CategoryId", "CategoryName");
            TempData["Message"] = "Create product successful";
            return Page();
        }
    }
}
