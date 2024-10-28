using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IImportDetailRepository
    {
        Task CreateImportDetail(ImportDetail importDetail);
        Task<List<ImportDetail>> GetImportDetailByImportId(int importId);
    }
}
