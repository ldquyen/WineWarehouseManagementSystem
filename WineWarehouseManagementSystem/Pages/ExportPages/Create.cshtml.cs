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

        public async Task OnGet()
        {
            Export = new Export
            {
                ExportDate = DateOnly.FromDateTime(DateTime.Now),
                AccountId = HttpContext.Session.GetInt32("accountId")
            };

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
            return RedirectToPage("/ExportPages/View");

        }

    }
}
