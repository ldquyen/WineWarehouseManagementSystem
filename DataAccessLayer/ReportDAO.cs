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
        public async Task AddReportAsync(Report report)
        {
            await _context.Set<Report>().AddAsync(report);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReportAsync(Report report)
        {
            _context.Set<Report>().Update(report);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReportAsync(int reportId)
        {
            var report = await _context.Set<Report>().FindAsync(reportId);
            if (report != null)
            {
                _context.Set<Report>().Remove(report);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Report>> GetAllReportsAsync()
        {
            return await _context.Set<Report>().ToListAsync();
        }

        public async Task<Report> GetReportByIdAsync(int reportId)
        {
            return await _context.Set<Report>().FindAsync(reportId);
        }
    }
}
