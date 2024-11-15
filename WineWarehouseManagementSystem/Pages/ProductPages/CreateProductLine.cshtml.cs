using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.ProductPages
{
    public class CreateProductLineModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IShelfRepository _shelfRepository;
        private readonly IProductLineRepostiory _productLineRepostiory;
        private readonly IImportDetailRepository _importDetailRepository;

        public CreateProductLineModel(IProductRepository productRepository, IShelfRepository shelfRepository, 
            IProductLineRepostiory productLineRepostiory, IImportDetailRepository importDetailRepository)
        {
            _productRepository = productRepository;
            _shelfRepository = shelfRepository;
            _productLineRepostiory = productLineRepostiory;
            _importDetailRepository = importDetailRepository;
        }

        [BindProperty(SupportsGet = true)]
        public int ImportId { get; set; }

        [BindProperty]
        public ProductLine productLine { get; set; }    
        public SelectList ProductList {  get; set; }
        public SelectList ShelfList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            await LoadData();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(productLine.ProductYear < 0 || productLine.ProductYear > DateTime.Now.Year)
            {
                TempData["Message"] = "Create import fail because year is invalid";
                await LoadData();
                return Page();
            }
            if (productLine.ProductAlcohol <= 0 || productLine.Price <= 0 || productLine.Capacity <= 0 || productLine.Quantity <= 0)
            {
                TempData["Message"] = "Create import fail because invalid number";
                await LoadData();
                return Page();
            }
            if (!decimal.TryParse(productLine.Price.ToString(), out decimal priceValue) || priceValue < 0)
            {
                TempData["Message"] = "Create import fail because price must be a valid number";
                await LoadData();
                return Page();
            }

            /*
            1. check xem th? là n?u ch?n sheld ðó th? sl có ð? ð? thêm vào shelf ko
            2. check xem th? n?u add ðc vào shelf th? check xem PL ð? t?n t?i ch
            3. n?u cùng PL th? add vào PL và Shelf
            4. n?u khác PL th? thêm m?i PL và add vào shelf
             */

            if (await _shelfRepository.AddShelfQuantity(productLine.ShelfId, productLine.Quantity))
            {
                var productLineExist = await _productLineRepostiory.GetProductIdByInfor(productLine.ProductId, productLine.ProductYear, productLine.ShelfId);
                if(productLineExist == null)            //n?u khác PL th? thêm m?i PL và add vào shelf
                {
                    await _productLineRepostiory.CreateProductLine(productLine);
                    ImportDetail importDetail = new ImportDetail()
                    {
                        ImportId = ImportId,
                        ProductLineId = productLine.ProductLineId,
                        Quantity = productLine.Quantity,
                    };
                    await _importDetailRepository.CreateImportDetail(importDetail);
                    TempData["Message"] = "Create import successfull, create new product line";
                    await LoadData();
                    return Page();
                }
                else                //n?u cùng PL th? add vào PL và Shelf
                {
                    var add = await _productLineRepostiory.AddQuantityToProductLine((int)productLineExist.ProductLineId, (int)productLine.Quantity);
                    if (add)
                    {
                        ImportDetail importDetail = new ImportDetail()
                        {
                            ImportId = ImportId,
                            ProductLineId = productLineExist.ProductLineId,
                            Quantity = productLine.Quantity,
                        };
                        await _importDetailRepository.CreateImportDetail(importDetail);
                        TempData["Message"] = "Create import successfull, update quantity to product line";
                        await LoadData();
                        return Page();
                    }
                    else
                    {
                        TempData["Message"] = "Create import unsuccessfull";
                        await LoadData();
                        return Page();
                    }
                }
            }
            else
            {
                TempData["Message"] = "Create import fail because quantiy at shelf is max";
                await LoadData();
                return Page();
            }
        }

        private async Task LoadData()
        {
            var products = await _productRepository.GetAll();
            ProductList = new SelectList(products, "ProductId", "ProductName");
            var shelfs = await _shelfRepository.GetAllShelf();
            ShelfList = new SelectList(shelfs, "ShelfId", "ShelfName");
        }
    }
}
