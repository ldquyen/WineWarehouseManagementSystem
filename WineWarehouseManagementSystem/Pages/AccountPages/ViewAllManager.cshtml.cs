using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.AccountPages
{
    public class ViewAllManagerModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        public ViewAllManagerModel(IAccountRepository accountRepository)
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
            accounts = await _accountRepository.GetManagerAccount();
            return Page();
        }
    }
}
