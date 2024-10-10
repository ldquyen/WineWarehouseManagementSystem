using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;
using System;

namespace WineWarehouseManagementSystem.Pages.ImportPages
{
    public class CreateImportModel : PageModel
    {
        private readonly IImportRepository _importRepository;
        public CreateImportModel(IImportRepository importRepository)
        {
            _importRepository = importRepository;
        }

        [BindProperty]
        public Import Import { get; set; }


        public void OnGet()
        {
            Import = new Import
            {
                ImportDate = DateOnly.FromDateTime(DateTime.Now),
                AccountId = HttpContext.Session.GetInt32("accountId")
            };
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Import = new Import
                {
                    ImportDate = DateOnly.FromDateTime(DateTime.Now),
                    AccountId = HttpContext.Session.GetInt32("accountId")
                };
                return Page(); 
            }
            await _importRepository.CreateImport(Import);
            int newimportId = Import.ImportId;
            return RedirectToPage("/ProductPages/CreateProductLine", new {ImportId = newimportId});
        }

    }
}
