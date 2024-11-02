using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IExportDetailRepository
    {
        public Task<dynamic> CreateExportDetailsAsync(ExportDetail exportDetails);
        public Task<dynamic> UpdateExportDetailsAsync(int exportDetailId);
        public Task DeleteExportDetailAsync(int exportDetailId);
        public Task<List<ExportDetail>> GetExportDetailsByExportId(int exportId);
    }
}
