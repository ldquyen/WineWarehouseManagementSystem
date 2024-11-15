using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.ProductPages
{
    public class ViewProductLineModel : PageModel
    {
        private readonly IProductLineRepostiory _productLineRepository;
        public ViewProductLineModel(IProductLineRepostiory productLineRepostiory)
        {
            _productLineRepository = productLineRepostiory;
        }

        [BindProperty]
        public List<ProductLine> productLines { get; set; }
        public async Task OnGet(int id)
        {
            await LoadData(id);
        }

        private async Task<IActionResult> LoadData(int id)
        {
            productLines = await _productLineRepository.GetProductLineListByProductId(id);
            return Page();
        }
    }
}
