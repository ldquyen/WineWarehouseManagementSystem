using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.AccountPages
{
    public class CreateStaffModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        public CreateStaffModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [BindProperty]
        public Account account { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (await _accountRepository.CheckName(account.AccountName))
            {
                TempData["Message"] = "Duplicate name";
                return Page();
            }
            if (await _accountRepository.CheckUsername(account.Username))
            {
                TempData["Message"] = "Duplicate username";
                return Page();
            }

            account.AccountRole = 1;
            await _accountRepository.CreateAccount(account);
            TempData["Message"] = "Create Staff account successful";
            return Page();
        }
    }
}
