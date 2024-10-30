using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ExportDetailDAO : SingletonBase<ExportDetailDAO>
    {
        public async Task<ExportDetail> GetExportDetailsById(int exportDetailsId)
        {
            return await _context.ExportDetails.FirstOrDefaultAsync(e => e.ExportId == exportDetailsId);
        }
        public async Task<List<ExportDetail>> GetExportDetailsByExportId(int exportId)
        {
            return await _context.ExportDetails.Where(x => x.ExportDetailId == exportId).Include(x => x.ProductLine)
                .ThenInclude(x => x.Product).Include(x => x.ProductLine).ThenInclude(x => x.Shelf).ToListAsync();
        }

        public async Task AddExportDetail(List<ExportDetail> exportDetails)
        {
            try
            {
                await _context.ExportDetails.AddRangeAsync(exportDetails);
                await _context.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new Exception($"Error at ExportDetailDAO: {ex.Message}");
            }
        }

        public async Task<dynamic> UpdateExportDetail(ExportDetail exportDetail)
        {
            try
            {
                _context.ExportDetails.Update(exportDetail);
                 return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error at ExportDetailDAO: {ex.Message}");
            }
        }

        public async Task DeleteExportDetails(int exportDetailsId)
        {
            try
            {
                var exportDetail = await _context.Exports.Where(e => e.ExportId == exportDetailsId).FirstOrDefaultAsync();
                _context.Exports.Remove(exportDetail);
                 await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error at ExportDAO: {ex.Message}");
            }
        }

    }
}
