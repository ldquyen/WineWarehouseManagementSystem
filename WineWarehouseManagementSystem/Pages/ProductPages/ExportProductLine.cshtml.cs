using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.ProductPages
{
    public class ExportProductLineModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IShelfRepository _shelfRepository;
        private readonly IProductLineRepostiory _productLineRepostiory;
        private readonly IImportDetailRepository _importDetailRepository;
        private readonly IExportDetailRepository _exportDetailRepository;
        public ExportProductLineModel(IProductRepository productRepository, IShelfRepository shelfRepository, IProductLineRepostiory productLineRepostiory, IImportDetailRepository importDetailRepository, IExportDetailRepository exportDetailRepository)
        {
            _productRepository = productRepository;
            _shelfRepository = shelfRepository;
            _productLineRepostiory = productLineRepostiory;
            _importDetailRepository = importDetailRepository;
            _exportDetailRepository = exportDetailRepository;
        }
        [BindProperty(SupportsGet = true)]
        public int ExportId { get; set; }
        [BindProperty]
        public ProductLine ProductLine { get; set; }
        public SelectList ProductList { get; set; }
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGet()
        {
            await LoadData();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            var productLine = await _productLineRepostiory.GetProductIdByInfor(ProductLine.ProductId, ProductLine.ProductYear, ProductLine.ShelfId);
            // Remove duplicates and assign to ManufacturingYearListOfProduct
            if (await _shelfRepository.ReduceShelfQuantity(ProductLine.ShelfId, ProductLine.Quantity))
            {
                await _productLineRepostiory.ReduceProductLine(productLine.ProductLineId, ProductLine.Quantity);
                ExportDetail exportDetail = new ExportDetail
                {
                    ExportId = ExportId,
                    ProductLineId = productLine.ProductLineId,
                    Quantity = ProductLine.Quantity,
                };
                await _exportDetailRepository.CreateExportDetailsAsync(exportDetail);
                TempData["Create"] = "Create export successfull";
                await LoadData();
                return RedirectToPage("/ProductPages/ExportPages/View");
            }
            else
            {
                TempData["Create"] = "Create export fail because quantiy is larger than available quantity";
                await LoadData();
                return Page();
            }
        }

        private async Task LoadData()
        {
            var products = await _productRepository.GetListOfProduct();
            ProductList = new SelectList(products, "ProductId", "ProductName");


        }
    }
}
