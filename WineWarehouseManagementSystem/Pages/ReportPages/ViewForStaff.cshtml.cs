using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.ReportPages
{
    public class ViewForStaffModel : PageModel
    {
        private readonly IReportRepository _reportRepository;
        private readonly ICheckingRequestRepository _checkingRequestRepository;
        private readonly IProductLineRepostiory _productLineRepostiory;

        public ViewForStaffModel(IReportRepository reportRepository, ICheckingRequestRepository checkingRequestRepository, IProductLineRepostiory productLineRepostiory)
        {
            _reportRepository = reportRepository;
            _checkingRequestRepository = checkingRequestRepository;
            _productLineRepostiory = productLineRepostiory;
        }

        [BindProperty]
        public List<Report> reports { get; set; }
        public async Task<IActionResult> OnGet()
        {
            int? accountId = HttpContext.Session.GetInt32("accountId");
            reports = await _reportRepository.GetReportNotCompleteByAccountID(accountId);
            return Page();
        }
       
        public async Task<IActionResult> OnPost(int id) //checkign req id
        {
            var checkRp = await _reportRepository.GetReportNotComplete(id);
            if (checkRp == null || !checkRp.Any())
            {
                var checkingReq = await _checkingRequestRepository.GetRequestByRequestId(id);
                if (checkingReq == null)
                {
                    TempData["Message"] = "Request not found";
                    return Page();
                }
                else
                {
                    int? productId = checkingReq.ProductId;
                    if (await _productLineRepostiory.CheckValidForChecking(productId))
                    {
                        var plList = await _productLineRepostiory.GetProductLineListForReportByProductId(productId); // lay pl can check voi dk quantity != 0
                        List<Report> rpList = new List<Report>();
                        foreach (var pl in plList)
                        {
                            Report report = new Report
                            {
                                ProductLineId = pl.ProductLineId,
                                CheckingRequestId = id,
                                StockQuantity = pl.Quantity,
                                CheckedQuantity = 0,
                                CheckedDate = DateOnly.FromDateTime(DateTime.Now),
                                Reason = "Not checking",
                                AccountId = HttpContext.Session.GetInt32("accountId"),
                                ReportStatus = false
                            };
                            rpList.Add(report);
                        }
                        var create = await _reportRepository.AddReports(rpList);
                        if (create)
                        {
                            reports = await _reportRepository.GetReportNotComplete(id);
                            return Page();
                        }
                        else
                        {
                            TempData["Message"] = "Can not create report";
                            return Page();
                        }
                    }
                    else
                    {
                        TempData["Message"] = "There is no valid quantity to check";
                        return Page();
                    }
                }
            }
            else
            {
                int? accountId = HttpContext.Session.GetInt32("accountId");
                reports = await _reportRepository.GetReportNotCompleteByAccountID(accountId);
                return Page();
            }
            
        }
    }
}
