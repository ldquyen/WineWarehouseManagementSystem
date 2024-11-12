using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public string userName { get; set; }
        [BindProperty]
        public string password { get; set; }

        private readonly IAccountRepository _accountRepository;
        public IndexModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
         
            try
            {
                var account = await _accountRepository.Login(userName, password);
                if (account != null)
                {
                    TempData["Message"] = "";
                    HttpContext.Session.SetInt32("accountId", account.AccountId);
                    HttpContext.Session.SetInt32("roleId", (int)account.AccountRole);
                    if (account.AccountRole == 1) return RedirectToPage("/StaffPage");
                    if (account.AccountRole == 2) return RedirectToPage("/ManagerPage");
                    if (account.AccountRole == 3) return RedirectToPage("/AdminPage");
                    return RedirectToPage("/Error");
                }
                else
                {
                    TempData["Message"] = "Login fail";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Page();
            }
        }
    }
}
