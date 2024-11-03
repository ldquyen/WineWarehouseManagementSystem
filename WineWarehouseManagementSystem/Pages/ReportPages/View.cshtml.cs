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

        public List<Report> Reports { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {         
            Reports = await _reportRepository.GetAllReports();
            return Page();
        }
    }
}
