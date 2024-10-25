using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccessLayer;

namespace WineWarehouseManagementSystem
{
    public class EditModel : PageModel
    {
        private readonly DataAccessLayer.WineWarehouseMsContext _context;

        public EditModel(DataAccessLayer.WineWarehouseMsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CheckingRequest CheckingRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkingrequest =  await _context.CheckingRequests.FirstOrDefaultAsync(m => m.CheckingRequestId == id);
            if (checkingrequest == null)
            {
                return NotFound();
            }
            CheckingRequest = checkingrequest;
           ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId");
           ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Origin");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CheckingRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckingRequestExists(CheckingRequest.CheckingRequestId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CheckingRequestExists(int id)
        {
            return _context.CheckingRequests.Any(e => e.CheckingRequestId == id);
        }
    }
}
