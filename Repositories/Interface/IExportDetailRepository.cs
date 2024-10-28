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
        public Task CreateExportDetailsAsync(List<ExportDetail> exportDetails);
        public Task<dynamic> UpdateExportDetailsAsync(int exportDetailId);
        public Task DeleteExportDetailAsync(int exportDetailId);

    }
}
