using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccessLayer;

namespace WineWarehouseManagementSystem
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccessLayer.WineWarehouseMsContext _context;

        public DeleteModel(DataAccessLayer.WineWarehouseMsContext context)
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

            var checkingrequest = await _context.CheckingRequests.FirstOrDefaultAsync(m => m.CheckingRequestId == id);

            if (checkingrequest == null)
            {
                return NotFound();
            }
            else
            {
                CheckingRequest = checkingrequest;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkingrequest = await _context.CheckingRequests.FindAsync(id);
            if (checkingrequest != null)
            {
                CheckingRequest = checkingrequest;
                _context.CheckingRequests.Remove(CheckingRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
