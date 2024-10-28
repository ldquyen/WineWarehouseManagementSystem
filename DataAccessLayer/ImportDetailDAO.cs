using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ImportDetailDAO : SingletonBase<ImportDetailDAO>
    {
        public async Task AddImportDetail(ImportDetail importDetails)
        {
            await _context.ImportDetails.AddAsync(importDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ImportDetail>> GetImportDetailsByImportId(int importId)
        {
            var list = await _context.ImportDetails.Where(x => x.ImportId == importId).Include(x => x.ProductLine)
                .ThenInclude(x => x.Product).Include(x => x.ProductLine).ThenInclude(x => x.Shelf).ToListAsync();
            return list;
        }
    }
}
