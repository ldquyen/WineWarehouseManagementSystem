using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WineWarehouseManagementSystem.Pages.CategoryPages
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public int CategoryId { get; set; }
        public void OnGet()
        {
        }
    }
}
