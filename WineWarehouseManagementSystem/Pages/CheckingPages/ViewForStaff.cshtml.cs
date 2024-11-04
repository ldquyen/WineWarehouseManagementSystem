using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.CheckingPages
{
    public class ViewForStaffModel : PageModel
    {
        private readonly ICheckingRequestRepository _checkingRequestRepository;

        public ViewForStaffModel(ICheckingRequestRepository checkingRequestRepository)
        {
            _checkingRequestRepository = checkingRequestRepository;
        }

        [BindProperty]
        public List<CheckingRequest> checkingRequests { get; set; } 
        public async Task OnGet()
        {
            await LoadData();
        }

        private async Task<IActionResult> LoadData()
        {
            checkingRequests = await _checkingRequestRepository.GetCheckingForStaff();
            //Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            //Response.Headers["Pragma"] = "no-cache";
            //Response.Headers["Expires"] = "0";
            return Page();
        }
    }
}
