using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using DataAccessLayer;

namespace WineWarehouseManagementSystem
{
    public class CreateModel : PageModel
    {
        private readonly DataAccessLayer.WineWarehouseMsContext _context;

        public CreateModel(DataAccessLayer.WineWarehouseMsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId");
        ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Origin");
            return Page();
        }

        [BindProperty]
        public CheckingRequest CheckingRequest { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CheckingRequests.Add(CheckingRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
