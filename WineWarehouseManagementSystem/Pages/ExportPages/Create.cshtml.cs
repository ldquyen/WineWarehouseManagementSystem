using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.ExportPages
{
    public class CreateModel : PageModel
    {
        private readonly IExportRepository _export;

        public CreateModel(IExportRepository export)
        {
            _export = export;
        }

        [BindProperty]
        public Export Export { get; set; }
        public void OnGet()
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
