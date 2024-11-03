using BusinessObject.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Interface;
using Repositories.Repository;
using System.Threading.Tasks;

namespace WineWarehouseManagementSystem.Pages.ReportPages
{
    public class CreateModel : PageModel
    {
        private readonly IReportRepository _reportRepository;
        private readonly IProductLineRepostiory _productLineRepository;

        public CreateModel(IReportRepository reportRepository, IProductLineRepostiory productLineRepository)
        {
            _reportRepository = reportRepository;
            _productLineRepository = productLineRepository;
        }

        [BindProperty]
        public SelectList ProductLineList { get; set; }

        [BindProperty]
        public Report Report { get; set; } = new Report();

        public async Task<IActionResult> OnGet(int requestId, int productId)
        {
            Report.CheckedDate = DateOnly.FromDateTime(DateTime.Now);
            Report.AccountId = HttpContext.Session.GetInt32("accountId").Value;
            await LoadData(productId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _reportRepository.AddReport(Report);
            return RedirectToPage("/StaffPage");
        }

        private async Task LoadData(int productId)
        {
            var products = await _productLineRepository.GetProductLineListByProductId(productId);
            ProductLineList = new SelectList(products, "ProductId", "ProductName");
        }
    }
}
