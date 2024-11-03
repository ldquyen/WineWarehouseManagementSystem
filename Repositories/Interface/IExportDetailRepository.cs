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
        Task<dynamic> CreateExportDetailsAsync(ExportDetail exportDetails);
        Task<dynamic> UpdateExportDetailsAsync(int exportDetailId);
        Task DeleteExportDetailAsync(int exportDetailId);
        Task<List<ExportDetail>> GetExportDetailsByExportId(int exportId);
    }
}
