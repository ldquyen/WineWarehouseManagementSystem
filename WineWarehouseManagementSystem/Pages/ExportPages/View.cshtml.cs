using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.ExportPages
{
    public class ViewModel : PageModel
    {
        private readonly IExportRepository _export;

        public ViewModel(IExportRepository export)
        {
            _export = export;
        }
        public List<Export> ExportList { get; set; }  = new List<Export>();
        public async Task OnGet(DateOnly exportDate)
        {
            if (!string.IsNullOrEmpty(exportDate.ToString()))
            {
                ExportList = await _export.GetAllExportAsync();
            }
            else
            {
                await OnGetSearchByExportDate(exportDate);
            }
        }

        public async Task<IActionResult> OnGetSearchByExportDate(DateOnly exportDate)
        {
            ExportList = await _export.GetExportByExportDateAsync(exportDate);
            return Page();
        }

    }
}
