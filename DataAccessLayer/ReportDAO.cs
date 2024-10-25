using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReportDAO : SingletonBase<ReportDAO>
    {
        public async Task AddChecking(CheckingRequest checking)
        {
            await _context.CheckingRequests.AddAsync(checking);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateChecking(CheckingRequest checking)
        {
            _context.CheckingRequests.Update(checking);
            await _context.SaveChangesAsync();
        }
        public async Task<List<CheckingRequest>> GetAllCheckingRequest()
        {
            return await _context.CheckingRequests.ToListAsync();
        }
    }
}
