using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.CheckingPages
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICheckingRequestRepository _checkingRequestRepository;
        private readonly IProductLineRepostiory _productLineRepository;

        public CreateModel(ICheckingRequestRepository checkingRequestRepository, IProductRepository productRepository, IProductLineRepostiory productLineRepository)
        {
            _checkingRequestRepository = checkingRequestRepository;
            _productRepository = productRepository;
            _productLineRepository = productLineRepository;

        }
        [BindProperty]
        public CheckingRequest CheckingRequest { get; set; }
        public SelectList ProductList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            CheckingRequest = new CheckingRequest
            {
                CheckDateRequest = DateTime.Now,
                AccountId = HttpContext.Session.GetInt32("accountId")
            };
            await LoadData();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                CheckingRequest = new CheckingRequest
                {
                    CheckDateRequest = DateTime.Now,
                    AccountId = HttpContext.Session.GetInt32("accountId"),
                };
                return Page();
            }
            var productLine = await _productLineRepository.GetProductLineListByProductId(CheckingRequest.ProductId);
            if (productLine != null)
            {
                TempData["Message"] = "The product dont have product line";
                await LoadData();
                return Page();
            }
            else
            {
                await _checkingRequestRepository.AddChecking(CheckingRequest);
                TempData["Message"] = "Ban da lam kho nhan vien cua ban thanh cong!";
                await LoadData();
                return RedirectToPage("/CheckingPages/View");
            }
        }
        private async Task LoadData()
        {
            var products = await _productRepository.GetAll();
            ProductList = new SelectList(products, "ProductId", "ProductName");
        }
    }
}
