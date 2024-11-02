using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.AccountPages
{
    public class UpdateStaffModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateStaffModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [BindProperty]
        public Account account { get; set; }
        public async Task OnGet(int id)
        {
            await LoadData(id);
        }

        public async Task<IActionResult> OnPost()
        {
            await _accountRepository.UpdateAccount(account);
            TempData["Message"] = "Update account successful";
            return Page();
        }

        private async Task<IActionResult> LoadData(int accountId)
        {
            account = await _accountRepository.GetAccountById(accountId);
            return Page();
        }
    }
}
