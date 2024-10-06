using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ExportDAO : SingletonBase<ExportDAO>
    {
        public async Task AddExport(Export export)
        {
            await _context.Exports.AddAsync(export);
            await _context.SaveChangesAsync();
        }
    }
}
