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
    public class IndexModel : PageModel
    {
        private readonly DataAccessLayer.WineWarehouseMsContext _context;

        public IndexModel(DataAccessLayer.WineWarehouseMsContext context)
        {
            _context = context;
        }

        public IList<CheckingRequest> CheckingRequest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CheckingRequest = await _context.CheckingRequests
                .Include(c => c.Account)
                .Include(c => c.Product).ToListAsync();
        }
    }
}
