using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.QuickInfo;
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
        [BindProperty]
        public int Quantity { get; set; }




        public async Task<IActionResult> OnGet()
        {
            await LoadData();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            var productLines = await _productLineRepostiory.GetProductLineForExport(ProductLine.ProductId, ProductLine.ProductYear); 
            if (productLines != null && productLines.Any())
            {
                int productQuantity = await _productLineRepostiory.CountQuantityForExport(ProductLine.ProductId, ProductLine.ProductYear); 
                if (productQuantity >= Quantity)
                {
                    int quantityNow = Quantity; //xuat 40
                    foreach (var pl in productLines)
                    {
                        if(pl.Quantity != 0)
                        {
                            int? reduce = 0;
                            if (quantityNow <= 0) break;
                            if (pl.Quantity >= quantityNow) //50 >= 40
                            {
                                reduce = quantityNow; // neu ma sl xuat be hon quantity thi reduce = sl xuat
                                pl.Quantity -= quantityNow; // 50 - 40
                                quantityNow = 0;
                            }
                            else
                            {
                                reduce = pl.Quantity;
                                quantityNow -= pl.Quantity.Value;
                                pl.Quantity = 0;
                            }
                            await _shelfRepository.ReduceShelfQuantity(pl.ShelfId, reduce);
                            await _productLineRepostiory.UpdateAsync(pl);
                            ExportDetail exportDetail = new ExportDetail
                            {
                                ExportId = ExportId,
                                ProductLineId = pl.ProductLineId,
                                Quantity = reduce
                            };
                            await _exportDetailRepository.CreateExportDetailsAsync(exportDetail);
                        }
                    }
                    if (quantityNow == 0)
                    {
                        TempData["Message"] = "Export successful";
                        await LoadData();
                        return Page();
                    }
                    else
                    {
                        TempData["Message"] = "Some product could not be exported";
                        await LoadData();
                        return Page();
                    }
                }
                else
                {
                    TempData["Message"] = "Can not export more than quantity available";
                    await LoadData();
                    return Page();
                }
                    
            }
            else
            {
                TempData["Message"] = "Can not find product line available";
                await LoadData();
                return Page();
            }
        }

        private async Task LoadData()
        {
            var products = await _productRepository.GetListOfProduct();
            ProductList = new SelectList(products, "ProductId", "ProductName");
        }

        private async Task<IActionResult> Export()
        {
            var productLines = await _productLineRepostiory.GetProductLineForExport(ProductLine.ProductId, ProductLine.ProductYear); // lấy ra được danh sách 
            if (productLines != null)
            {
                int productQuantity = await _productLineRepostiory.CountQuantityForExport(ProductLine.ProductId, ProductLine.ProductYear); // lấy ra được quantity tổng trong productLine
                if (productQuantity >= Quantity)
                {
                    int quantityNow = Quantity;
                    foreach (var pl in productLines)
                    {
                        if (quantityNow <= 0) break;
                        if (pl.Quantity >= quantityNow)
                        {
                            pl.Quantity -= quantityNow;
                            quantityNow = 0;
                        }
                        else
                        {
                            quantityNow -= pl.Quantity.Value;
                            pl.Quantity = 0;
                        }
                        await _productLineRepostiory.UpdateAsync(pl);
                    }
                    if (quantityNow == 0)
                        TempData["Message"] = "Export successful";
                    else
                        TempData["Message"] = "Some product could not be exported";
                }
                else
                    TempData["Message"] = "Can not export more than quantity available";
            }
            else
                TempData["Message"] = "Can not find product line available";
            
            return Page();
        }
    }
}
/*
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
 */