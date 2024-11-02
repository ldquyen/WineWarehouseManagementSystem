using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.ExportPages
{
    public class ViewExportDetailModel : PageModel
    {
        private readonly IExportDetailRepository _repository;

        public ViewExportDetailModel(IExportDetailRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public List<ExportDetail> exportDetails { get; set; }
        public async Task OnGet(int id)
        {
            await LoadData(id);
        }

        private async Task<IActionResult> LoadData(int exportId)
        {
            exportDetails = new List<ExportDetail>();
            exportDetails = await _repository.GetExportDetailsByExportId(exportId);
            return Page();
        }

    }
}
