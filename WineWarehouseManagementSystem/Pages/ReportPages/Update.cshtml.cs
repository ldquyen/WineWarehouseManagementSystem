using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.ReportPages
{
    public class UpdateModel : PageModel
    {
        private readonly IReportRepository _reportRepository;
        private readonly ICheckingRequestRepository _checkingRequestRepository;

        public UpdateModel(IReportRepository reportRepository, ICheckingRequestRepository checkingRequestRepository)
        {
            _reportRepository = reportRepository;
            _checkingRequestRepository = checkingRequestRepository;
        }
        [BindProperty]
        public Report report { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            await LoadData(id);
            return Page();
        }

        private async Task LoadData(int reportId)
        {
            report = await _reportRepository.GetReportByReportId(reportId) ;
            if (report == null)
            {
                TempData["Message"] = "Report not found.";

            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (report.CheckedQuantity < 0 || report.CheckedQuantity > report.StockQuantity)
            {
                TempData["Message"] = "Check quantity is wrong.";
                return Page();
            }
            
            if(report.Reason == "Not checking")
            {
                TempData["Message"] = "Please update reason before update.";
                return Page();
            }

            var reportToUpdate = await _reportRepository.GetReportByReportId(report.ReportId);
            if (reportToUpdate != null)
            {
                reportToUpdate.CheckedQuantity = report.CheckedQuantity;
                reportToUpdate.Reason = report.Reason;
                reportToUpdate.ReportStatus = true;

                await _reportRepository.UpdateReport(reportToUpdate);
            }

            var listRp = await _reportRepository.GetReportListByCheckingId((int)reportToUpdate.CheckingRequestId);
            bool allReportsChecked = listRp.Any(rp => rp.ReportStatus == false);

            if (!allReportsChecked)
            {
                var checkingReq = await _checkingRequestRepository.GetRequestByRequestId((int)report.CheckingRequestId);
                checkingReq.CheckingStatus = true;
                await _checkingRequestRepository.UpdateChecking(checkingReq);
            }
            await LoadData(reportToUpdate.ReportId);
            return RedirectToPage("/ReportPages/ViewForStaff");
        }
    }
}
