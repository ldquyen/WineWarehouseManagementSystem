using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.ImportPages
{
    public class ViewModel : PageModel
    {
        private readonly IImportRepository _importRepository;

        public ViewModel()
        {
            _importRepository = new ImportRepository();
        }

        [BindProperty]
        public List<Import> Imports { get; set; }

        [BindProperty]
        public DateOnly? StartDate { get; set; }
        [BindProperty]
        public DateOnly? EndDate { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Imports = await _importRepository.GetImportList(null, null);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (StartDate != null & EndDate != null)
            {
                Imports = await _importRepository.GetImportList(StartDate, EndDate);
                return Page();
            }
            else
            {
                Imports = await _importRepository.GetImportList(null, null);
                return Page();
            }
            
        }


    }
}
