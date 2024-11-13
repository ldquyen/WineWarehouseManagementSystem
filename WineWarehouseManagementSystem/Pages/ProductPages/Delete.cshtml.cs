using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.ProductPages
{
    public class DeleteModel : PageModel
    {
        private readonly IProductLineRepostiory _productLineRepostiory;
        private readonly IProductRepository _productRepository;
        public DeleteModel(IProductLineRepostiory productLineRepostiory, IProductRepository productRepository)
        {
            _productLineRepostiory = productLineRepostiory;
            _productRepository = productRepository;
        }

        [BindProperty]
        public Product product { get; set; }
        public async Task OnGet(int id)
        {
            product = await _productRepository.GetProductById(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if(await _productLineRepostiory.CheckProductLineWithProductId(id))
            {
                product = await _productRepository.GetProductById(id);
                TempData["Message"] = "Can not delete this product because it has product line";
                return Page();
            }
            else
            {
                var delete = await _productRepository.DeleteProduct(id);
                if (delete)
                {
                    TempData["Message"] = "Delete product sucessful";
                    return Page();
                }
                else
                {
                    product = await _productRepository.GetProductById(id);
                    TempData["Message"] = "Can not delete this product because some errors";
                    return Page();
                }
            }
            
        }
    }
}
