using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.ExportPages
{
    public class CreateModel : PageModel
    {
        private readonly IExportRepository _export;
        private readonly IProductRepository _productRepository;
        public CreateModel(IExportRepository export, IProductRepository productRepository)
        {
            _export = export;
            _productRepository = productRepository;
        }

        [BindProperty]
        public Export Export { get; set; }
        public Product product { get; set; }
        public SelectList ProductList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Export = new Export
            {
                ExportDate = DateOnly.FromDateTime(DateTime.Now),
                AccountId = HttpContext.Session.GetInt32("accountId")
            };
            await LoadData();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Export = new Export
                {
                    ExportDate = DateOnly.FromDateTime(DateTime.Now),
                    AccountId = HttpContext.Session.GetInt32("accountId")
                };
                return Page();
            }
            await _export.CreateExportAsync(Export);
            int newExportId = Export.ExportId;
            int productId = product.ProductId;
            string? productName = product.ProductName;  
            return RedirectToPage("/ProductPages/ExportProductLine", new
            {
                ExportId = newExportId,
                ProductName = productName,
                ProductId = productId,
            });

        }
        private async Task LoadData()
        {
            var products = await _productRepository.GetListOfProduct();
            ProductList = new SelectList(products, "ProductId", "ProductName");
        }
    }
}
