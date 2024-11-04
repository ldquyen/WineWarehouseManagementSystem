using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.ProductPages
{
    public class UpdateQuantityModel : PageModel
    {
        private readonly IReportRepository _reportRepository;
        private readonly IProductLineRepostiory _productLineRepostiory;
        private readonly IShelfRepository _shelfRepository;

        public UpdateQuantityModel(IReportRepository reportRepository, IProductLineRepostiory productLineRepostiory, IShelfRepository shelfRepository)
        {
            _reportRepository = reportRepository;
            _productLineRepostiory = productLineRepostiory;
            _shelfRepository = shelfRepository;
        }

        [BindProperty]
        public List<Report> reports { get; set; }
        public async Task OnGet()
        {
            await LoadData();
        }

        private async Task<IActionResult> LoadData()
        {
            reports = await _reportRepository.GetReportListToUpdateForAdmin();
            return Page();
        }

        public async Task OnPost(int id)
        {
            var report = await _reportRepository.GetReportByReportId(id);
            if (report == null)
            {
                TempData["Message"] = "Can not find report";
                await LoadData();
            }
            else
            {
                int? errorQuantity = report.StockQuantity - report.CheckedQuantity;
                int productLineid = (int)report.ProductLineId;
                var productLine = await _productLineRepostiory.GetProductLineByProductLineId(productLineid);
                if (productLine == null)
                {
                    TempData["Message"] = "Can not find product line";
                    await LoadData();
                }
                var shelf = await _shelfRepository.GetShelfByShelfId(productLine?.ShelfId);
                if(shelf == null)
                {
                    TempData["Message"] = "Can not find shelf";
                    await LoadData();
                }

                if (productLine.Quantity != report.StockQuantity)
                {
                    TempData["Message"] = "Stock quantity in report is different with quantity in product line";
                    await LoadData();
                }
                else
                {
                    productLine.Quantity -= errorQuantity;
                    shelf.UseQuantity -= errorQuantity;
                    await _productLineRepostiory.UpdateAsync(productLine);
                    await _shelfRepository.UpdateShelf(shelf);
                    TempData["Message"] = "Update quantity successful";
                    await LoadData();
                }

            }
        }
    }
}
