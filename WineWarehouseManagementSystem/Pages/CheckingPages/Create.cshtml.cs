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
        public CreateModel(ICheckingRequestRepository checkingRequestRepository, IProductRepository productRepository)
        {
            _checkingRequestRepository = checkingRequestRepository;
            _productRepository = productRepository;
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
            await _checkingRequestRepository.AddChecking(CheckingRequest);
            TempData["Message"] = "Ban da lam kho nhan vien cua ban thanh cong!";
            await LoadData();
            return Page();
        }
        private async Task LoadData()
        {
            var products = await _productRepository.GetAll();
            ProductList = new SelectList(products, "ProductId", "ProductName");
        }
    }
}
