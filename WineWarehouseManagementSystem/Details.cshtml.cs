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
    public class DetailsModel : PageModel
    {
        private readonly DataAccessLayer.WineWarehouseMsContext _context;

        public DetailsModel(DataAccessLayer.WineWarehouseMsContext context)
        {
            _context = context;
        }

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
    }
}
