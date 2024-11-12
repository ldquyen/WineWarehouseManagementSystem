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
        public async Task<bool> AddReports(List<Report> reportList)
        {
            try
            {
                await _context.Reports.AddRangeAsync(reportList);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Report>> GetReportNotComplete(int checkingReqId)
        {
            return await _context.Reports.Where(x => x.CheckingRequestId == checkingReqId && x.ReportStatus == false).AsNoTracking().ToListAsync();
        }

        public async Task<List<Report>> GetReportNotComplete(int? accountId)
        {
            return await _context.Reports.Where(x => x.AccountId == accountId && x.ReportStatus == false).AsNoTracking().ToListAsync();
        }

        public async Task<Report> GetReportById(int reportId)
        {
            return await _context.Reports.FirstOrDefaultAsync(x => x.ReportId == reportId);
        }

        public async Task UpdateReportForCheck(Report report)
        {
            _context.Reports.Update(report);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Report>> GetReportListById(int reportId)
        {
            return await _context.Reports.AsNoTracking().Where(x => x.ReportId==reportId).AsNoTracking().ToListAsync();
        }

        public async Task<List<Report>> GetReportListByCheckingId(int checkingId)
        {
            return await _context.Reports.Where(x => x.CheckingRequestId == checkingId).Include(x => x.Account).AsNoTracking().ToListAsync();
        }

        public async Task<List<Report>> GetReportListToUpdateForAdmin()
        {
            return await _context.Reports.Where(x => x.ReportStatus == true && x.StockQuantity != x.CheckedQuantity).AsNoTracking().ToListAsync();
        }
    }
}
