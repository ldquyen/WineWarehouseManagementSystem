using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ExportDetailDAO : SingletonBase<ExportDetailDAO>
    {
        public async Task AddExportDetail(List<ExportDetail> exportDetails)
        {
            await _context.ExportDetails.AddRangeAsync(exportDetails);
            await _context.SaveChangesAsync();
        }
    }
}
