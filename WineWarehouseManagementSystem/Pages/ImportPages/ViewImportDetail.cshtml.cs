using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.ImportPages
{
    public class ViewImportDetailModel : PageModel
    {
        private readonly IImportDetailRepository _importDetailRepository;

        public ViewImportDetailModel(IImportDetailRepository importDetailRepository)
        {
            _importDetailRepository = importDetailRepository;
        }

        [BindProperty]
        public List<ImportDetail> importDetails { get; set; }
        public async Task OnGet(int id)
        {
            await LoadData(id);
        }

        private async Task<IActionResult> LoadData(int importId)
        {
            importDetails = new List<ImportDetail>();
            importDetails = await _importDetailRepository.GetImportDetailByImportId(importId);
            return Page();
        }
    }
}
