using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ExportDAO : SingletonBase<ExportDAO>
    {

        public async Task<Export> GetExportById(int exportId)
        {
            return await _context.Exports.FirstOrDefaultAsync(e => e.ExportId == exportId);
        }

        public async Task<Export> GetExportByAccountId(int accountId)
        {
            return await _context.Exports.FirstOrDefaultAsync(e => e.AccountId == accountId);
        }

        public async Task<List<Export>> GetExportByExportDate(DateOnly exportDate)
        {
            return await _context.Exports.Include(e => e.Account).Where(e => e.ExportDate == exportDate).ToListAsync();
        }
        public async Task<List<Export>> GetAllExports()
        {
            return await _context.Exports.Include(e => e.Account).ToListAsync();
        }
        public async Task<dynamic> AddExport(Export export)
        {
            try
            {
                await _context.Exports.AddAsync(export);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error at ExportDAO: {ex.Message}");
            }
        }

        public async Task<dynamic> UpdateExport(Export export)
        {
            try
            {
                _context.Exports.Update(export);
                return await _context.SaveChangesAsync() > 0;
            } catch (Exception ex)
            {
                throw new Exception($"Error at ExportDAO: {ex.Message}");
            }
        }

        public async Task<dynamic> DeleteExport(int exportId)
        {
            try
            {
                var export = await _context.Exports.Where(e => e.ExportId == exportId).FirstOrDefaultAsync();
                _context.Exports.Remove(export);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error at ExportDAO: {ex.Message}");
            }
        }
    }
}
