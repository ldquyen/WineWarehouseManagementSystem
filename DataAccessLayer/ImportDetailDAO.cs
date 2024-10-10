using BusinessObject.Models;
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
    }
}
