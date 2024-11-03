using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

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
        public List<Report> Reports { get; set; }

        public async Task OnGet()
        {
            await LoadData();
        }

        private async Task<IActionResult> LoadData()
        {
            Reports = await _reportRepository.GetAllReports();
            return Page();
        }
    }
}
