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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var account = await _accountRepository.Login(userName, password);
                if (account != null)
                {
                    TempData["Message"] = "Login oke";
                    
                }
                else
                {
                    TempData["Message"] = "Login fail";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Page(); 
        }
    }
}
