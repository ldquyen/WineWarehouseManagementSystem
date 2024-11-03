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

        public List<CheckingRequest> CheckingRequests { get; set; }

        public async Task OnGetAsync()
        {
            CheckingRequests = await _checkingRequestRepository.GetAllCheckingRequestsAsync();
        }
    }
}
