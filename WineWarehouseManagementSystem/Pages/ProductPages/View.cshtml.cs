using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.ProductPages
{
    public class ViewModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        public List<Product> ProductList { get; set; } = new List<Product>();
        public ViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task OnGet(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ProductList = await _productRepository.GetAll();
            }
            else
            {
                await OnGetSearchByName(name);
            }
        }

        public async Task<IActionResult> OnGetSearchByName(string name)
        {
            ProductList = await _productRepository.GetProductByName(name);
            return Page();
        }
    }
}
