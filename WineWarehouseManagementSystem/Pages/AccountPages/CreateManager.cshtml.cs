using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.AccountPages
{
    public class CreateManagerModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        public CreateManagerModel(IAccountRepository accountRepository)
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

            account.AccountRole = 2;
            await _accountRepository.CreateAccount(account);
            TempData["Message"] = "Create manager account successful";
            return Page();
        }
    }
}
