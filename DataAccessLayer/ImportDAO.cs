using BusinessObject.Models;
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
    }
}
