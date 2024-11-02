using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.AccountPages
{
    public class ViewAllStaffModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        public ViewAllStaffModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [BindProperty]
        public List<Account> accounts { get; set; }
        public async Task OnGet()
        {
            await LoadData();
        }

        private async Task<IActionResult> LoadData()
        {
            accounts = await _accountRepository.GetStaffList();
            return Page();
        }
    }
}
