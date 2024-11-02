using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.ProductPages
{
    public class ExportProductLineModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IShelfRepository _shelfRepository;
        private readonly IProductLineRepostiory _productLineRepostiory;
        private readonly IImportDetailRepository _importDetailRepository;

        public ExportProductLineModel(IProductRepository productRepository, IShelfRepository shelfRepository, IProductLineRepostiory productLineRepostiory, IImportDetailRepository importDetailRepository)
        {
            _productRepository = productRepository;
            _shelfRepository = shelfRepository;
            _productLineRepostiory = productLineRepostiory;
            _importDetailRepository = importDetailRepository;
        }
        [BindProperty(SupportsGet = true)]
        public int ExportId { get; set; }
        public int ProductName { get; set; }
        public int ProductId { get; set; }
        [BindProperty]
        public ProductLine productLine { get; set; }
        public SelectList ManufacturingYearListOfProduct { get; set; }
        public SelectList ShelfList { get; set; }
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGet()
        {
            await LoadData();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (await _shelfRepository.ReduceShelfQuantity(productLine.ShelfId, productLine.Quantity))
            {
                await _productLineRepostiory.ReduceProductLine(productLine.ProductLineId, Quantity);
                TempData["Create"] = "Create export successfull";
                await LoadData();
                return Page();
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

            var shelfs = await _shelfRepository.GetShelfsOfProductLineByProductId(ProductId);
            ShelfList = new SelectList(shelfs, "ShelfId", "ShelfName");
            var years = await _productLineRepostiory.GetListManufacturingYearOfProduct(ProductId);
            ManufacturingYearListOfProduct = new SelectList(years ,"ProductYear");
        }
    }
}
