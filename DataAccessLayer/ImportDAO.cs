using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ImportDAO : SingletonBase<ImportDAO>
    {
        public async Task AddImport(Import import)
        {
            await _context.Imports.AddAsync(import);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Import>> GetImportList(DateOnly? StartDate, DateOnly? EndDate)
        {
            if(StartDate != null && EndDate != null)
            {
                return await _context.Imports.Where(x => x.ImportDate >= StartDate && x.ImportDate <= EndDate).Include(x => x.ImportDetails)
                .Include(x => x.Account).OrderByDescending(x => x.ImportDate).ToListAsync();
            }
            else
            {
                return await _context.Imports.Include(x => x.ImportDetails).Include(x => x.Account).OrderByDescending(x => x.ImportDate).ToListAsync();
            }
        }
    }
}
