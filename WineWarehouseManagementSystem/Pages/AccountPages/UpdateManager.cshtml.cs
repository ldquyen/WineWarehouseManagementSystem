using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.AccountPages
{
    public class UpdateManagerModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateManagerModel(IAccountRepository accountRepository)
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
