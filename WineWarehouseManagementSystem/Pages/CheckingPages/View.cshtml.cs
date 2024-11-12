using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.CheckingPages
{
    public class ViewModel : PageModel
    {
        private readonly ICheckingRequestRepository _checkingRequestRepository;

        public ViewModel(ICheckingRequestRepository checkingRequestRepository)
        {
            _checkingRequestRepository = checkingRequestRepository;
        }
        [BindProperty]
        public List<CheckingRequest> CheckingRequests { get; set; }

        public async Task<IActionResult> OnGet()
        {
            await LoadData();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await LoadData();
            return Page();
        }

        public async Task LoadData()
        {
            CheckingRequests = await _checkingRequestRepository.GetAllChecking();
        }
    }
}
