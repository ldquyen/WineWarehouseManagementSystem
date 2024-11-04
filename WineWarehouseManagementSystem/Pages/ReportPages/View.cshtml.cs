using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.ReportPages
{
    public class ViewModel : PageModel
    {
        private readonly IReportRepository _reportRepository;
        public ViewModel(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        [BindProperty]
        public List<Report> reports { get; set; }
        public async Task OnGet(int id) // check req id
        {
            await LoadData(id);
        }

        private async Task<IActionResult> LoadData(int checkingRequestId)
        {
            reports = await _reportRepository.GetReportListByCheckingId(checkingRequestId);
            return Page();
        }
    }
}
